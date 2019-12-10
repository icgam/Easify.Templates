using Easify.Ef.Testing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Template.Core.Data;
using Template.WebApi.Extensions;

namespace Template.WebApi.IntegrationTests.Setup
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