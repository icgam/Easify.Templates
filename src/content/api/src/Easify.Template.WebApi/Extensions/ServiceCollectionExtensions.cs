using System.Reflection;
using Easify.Ef;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Easify.Template.Core.Data;
using Easify.Template.Core.Shared;

namespace Easify.Template.WebApi.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddMediatR(typeof(HandlerBase).GetTypeInfo().Assembly);
            return services;
        }

        public static IServiceCollection AddRestClients(this IServiceCollection services)
        {
            return services;
        }

        public static IServiceCollection AddDbServices(this IServiceCollection services,
            IConfiguration configuration)

        {
            services.AddSqlDbContext<AppDbContext>(
                configuration.GetConnectionString("AppDatabase"));

            return services;
        }
    }
}