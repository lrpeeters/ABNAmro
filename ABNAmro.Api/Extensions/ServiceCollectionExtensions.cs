using ABNAmro.Application.Extensions;
using ABNAmro.Database.Extensions;
using Microsoft.Extensions.DependencyInjection;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace ABNAmro.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureABNAmroServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
            {
                return services;
            }

            // Application
            services.RegisterMappings();
            services.RegisterCommands();
            services.RegisterQueries();

            // Database
            services.RegisterRepositories();
            services.RegisterDatabaseService(configuration);

            return services;
        }
    }
}
