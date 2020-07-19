using Microsoft.Extensions.DependencyInjection;
using System;

namespace Infrastructure.Services
{
    public static class ServiceFactory
    {
        private static IServiceProvider _provider;

        public static void Init(IServiceProvider provider)
        {
            _provider = provider;
        }

        public static IServiceProvider GetProvider()
        {
            return _provider;
        }

        public static T GetService<T>()
        {
            return _provider.GetRequiredService<T>();
        }

    }
}
