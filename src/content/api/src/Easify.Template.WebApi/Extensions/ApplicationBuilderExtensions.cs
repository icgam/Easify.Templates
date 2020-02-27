using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace Easify.Template.WebApi.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void UseStartPage(this IApplicationBuilder app, string applicationName)
        {
            if (app == null) throw new ArgumentNullException(nameof(app));
            if (applicationName == null) throw new ArgumentNullException(nameof(applicationName));

            app.Run(async context =>
            {
                var content = LoadStartPageFromEmbeddedResource(applicationName);
                if (string.IsNullOrEmpty(content))
                    content = applicationName;

                context.Response.ContentType = "text/html";
                await context.Response.WriteAsync(content);
            });
        }

        private static string LoadStartPageFromEmbeddedResource(string applicationName)
        {
            var assembly = typeof(Startup).Assembly;
            var resourceName = assembly.GetManifestResourceNames().First(s => s.EndsWith("home.html", StringComparison.CurrentCultureIgnoreCase));
            if (string.IsNullOrEmpty(resourceName))
                return null;

            try
            {
                var stream = typeof(Startup).Assembly.GetManifestResourceStream(resourceName);
                if (stream == null)
                    return null;

                using (var reader = new StreamReader(stream))
                {
                    var content = reader.ReadToEnd();
                    content = content.Replace("{{application}}", applicationName);
                    return content;
                }
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}