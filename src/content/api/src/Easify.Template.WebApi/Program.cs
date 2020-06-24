using Easify.AspNetCore;
using Easify.Logging.SeriLog.Loggly;
using Easify.Logging.SeriLog.Seq;
using Microsoft.AspNetCore.Hosting;

namespace Easify.Template.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            HostAsWeb.Run<Startup>(
                s =>
                {
                    return s.Environment.IsDevelopment()
                        ? s.ConfigureLogger<Startup>(c => c.UseSeq(s.Configuration.GetSection("Logging:Seq")))
                        : s.ConfigureLogger<Startup>(c => c.UseLoggly(s.Configuration.GetSection("Logging:Loggly")));
                }, args);
        }
    }
}