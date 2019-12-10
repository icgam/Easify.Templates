using Easify.AspNetCore;
using Easify.Logging.SeriLog.Loggly;
using Microsoft.AspNetCore.Hosting;

namespace Template.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebHost.Run<Startup>(s =>
            {
                if (s.Environment.IsDevelopment() || s.Environment.IsEnvironment("INT"))
                    return s.ConfigureLogger<Startup>();

                return s.ConfigureLogger<Startup>(c => c.UseLoggly(s.Configuration.GetSection("Logging:Loggly")));
            }, args);
        }
    }
}