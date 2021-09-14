using ABNAmro.Application.Extensions;
using ABNAmro.Database.Extensions;
using ABNAmro.Worker.Calculators;
using ABNAmro.Worker.Processors;
using Microsoft.Extensions.DependencyInjection;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace ABNAmro.Worker.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection ConfigureABNAmroServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
            {
                return services;
            }

            // Worker
            services.AddCalculators();
            services.AddProcessors();

            // Application
            services.RegisterMappings();
            services.RegisterCommands();
            services.RegisterQueries();

            // Database
            services.RegisterRepositories();
            services.RegisterDatabaseService(configuration);

            return services;
        }

        public static IServiceCollection AddCalculators(this IServiceCollection services)
        {
            services.AddTransient<ICalculator, LetterMatchCalculator>();
            return services;
        }

        public static IServiceCollection AddProcessors(this IServiceCollection services)
        {
            services.AddTransient<ICalculationsProcessor, CalculationsProcessor>();
            services.AddTransient<IProgressWriter, ProgressWriter>();
            return services;
        }
    }
}
