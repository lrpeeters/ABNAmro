using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ABNAmro.Database.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder MigrateDatabase(this IApplicationBuilder app, IServiceProvider serviceProvider, ILogger logger)
        {
            var context = serviceProvider.GetService<ABNAmroContext>();

            try
            {
                context.Database.Migrate();
            }
            catch (Exception ex)
            {
                logger.LogError("An error occured when trying to migrate the database on startup.", ex);
                throw;
            }

            return app;
        }
    }
}
