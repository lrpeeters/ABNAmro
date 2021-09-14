using ABNAmro.Application.Interfaces.Persistence;
using ABNAmro.Database.Repositories;
using ABNAmro.Domain.Calculations;
using ABNAmro.Domain.Progresses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ABNAmro.Database.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient<ICalculationRepository, CalculationRepository>();
            services.AddTransient<IRepository<Calculation>, CalculationRepository>();
            services.AddTransient<IProgressRepository, ProgressRepository>();
            services.AddTransient<IRepository<Progress>, ProgressRepository>();
            services.AddTransient<IRepositoryProvider, RepositoryProvider>();
            return services;
        }

        public static IServiceCollection RegisterDatabaseService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ABNAmroContext>(opts =>
            {
                opts.EnableSensitiveDataLogging();
                opts.UseSqlServer(configuration["ConnectionString:ABNAmro"]);
            }, ServiceLifetime.Transient, ServiceLifetime.Singleton);
            return services;
        }
    }
}
