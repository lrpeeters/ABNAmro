using System;
using ABNAmro.Worker.Processors;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ABNAmro.Worker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting ABN Amro Calculator worker");
            IConfiguration configuration = GetConfiguration();

            var services = Startup.Start(configuration);

            Console.WriteLine("ABN Amro Calculator started");

            var serviceProvider = services.BuildServiceProvider();
            var processor = serviceProvider.GetService<ICalculationsProcessor>();

            // Of course, this is a somewhat simple and inefficient way of using a worker, as it is not scalable, but setting up the alternatives (creating a master worker
            // that acts as a broker with several slaves, or having a bunch of workers that pick a messagge from an MQ takes too much time for this simple assesment. A totally
            // different approach would be to set it up as an Azure Function. Still no time though...
            processor.ExecuteAsync().Wait();

            Console.ReadKey();
        }

        private static IConfiguration GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json");

            IConfiguration configuration = builder.Build();
            return configuration;
        }
    }
}
