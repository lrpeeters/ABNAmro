using System;

namespace ABNAmro.CrossCutting.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static TService GetService<TService>(this IServiceProvider serviceProvider)
            where TService : class
        {
            if (serviceProvider == null)
            {
                return null;
            }

            return serviceProvider.GetService(typeof(TService)) as TService;
        }
    }
}
