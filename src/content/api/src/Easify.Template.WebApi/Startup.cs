using System;
using Easify.AspNetCore.Bootstrap;
using Easify.AspNetCore.Bootstrap.Extensions;
using Easify.Configurations;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Easify.Template.Core.Shared.Exceptions;
using Easify.Template.Core.Shared.Profiles;
using Easify.Template.WebApi.Configurations;
using Easify.Template.WebApi.Extensions;

namespace Easify.Template.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }


        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            return services.BootstrapApp<Startup>(Configuration,
                app => app
                    .AddConfigSection<Clients>()
                    .HandleApplicationException<AppException>()
                    .UseDetailedErrors()
                    .ConfigureCorrelation(m => m.AutoCorrelateRequests())
                    .ConfigureMappings(m => m.AddProfile<MappingProfile>())
                    .AddServices((container, config) => AddServices(container, config)));
        }

        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env,
            ILoggerFactory loggerFactory)
        {
            var application = Configuration.GetApplicationInfo();
            app.UseDefaultApiPipeline(Configuration, env, loggerFactory);
            app.UseStartPage(application.Name);
        }

        protected virtual IServiceCollection AddServices(IServiceCollection services, IConfiguration configuration)
        {
            return services
                .AddCoreServices()
                .AddRestClients()
                .AddDbServices(configuration);
        }
    }
}