using ABNAmro.Application.Commands;
using ABNAmro.Application.Commands.Calculations;
using ABNAmro.Application.Commands.Progresses;
using ABNAmro.Application.Mappings;
using ABNAmro.Application.Queries.Calculations;
using ABNAmro.Application.Queries.Progresses;
using Microsoft.Extensions.DependencyInjection;

namespace ABNAmro.Application.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection RegisterMappings(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapperProfile));
            return services;
        }

        public static IServiceCollection RegisterCommands(this IServiceCollection services)
        {
            services.AddTransient<ICreateCalculationCommand, CreateCalculationCommand>();
            services.AddTransient<ICreateCommand<CreateCalculation>, CreateCalculationCommand>();

            services.AddTransient<ICreateProgressCommand, CreateProgressCommand>();
            services.AddTransient<ICreateCommand<CreateProgress>, CreateProgressCommand>();

            return services;
        }

        public static IServiceCollection RegisterQueries(this IServiceCollection services)
        {
            services.AddTransient<IGetProgressByCalculationQuery, GetProgressByCalculationQuery>();
            services.AddTransient<IGetCalculationsWithoutProgressQuery, GetCalculationsWithoutProgressQuery>();
            return services;
        }
    }
}
