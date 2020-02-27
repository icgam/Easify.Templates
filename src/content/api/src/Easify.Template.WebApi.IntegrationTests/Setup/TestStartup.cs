using Easify.Ef.Testing;
using Easify.Template.Core.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Easify.Template.WebApi.Extensions;

namespace Easify.Template.WebApi.IntegrationTests.Setup
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration) : base(configuration) { }

        protected override IServiceCollection AddServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddCoreServices();
            services.AddRestClients();
            services.AddInMemoryUnitOfWork<AppDbContext>();

            return services;
        }
    }
}