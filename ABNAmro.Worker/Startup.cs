using ABNAmro.Worker.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ABNAmro.Worker
{
    internal class Startup
    {
        private readonly IConfiguration _configuration;

        private Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public static IServiceCollection Start(IConfiguration configuration)
        {
            var services = new ServiceCollection();
            var startup = new Startup(configuration);
            startup.ConfigureServices(services);
            return services;
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureABNAmroServices(_configuration);
        }

    }
}
