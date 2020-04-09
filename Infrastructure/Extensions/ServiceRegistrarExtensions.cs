using System;
using System.Reflection;

namespace Infrastructure.Extensions
{
    public static class ServiceRegistrarExtensions
    {
        public static IServiceRegistrar GetServiceRegistrar(this Type type)
        {
            if (typeof(IServiceRegistrar).GetTypeInfo().IsAssignableFrom(type))
            {
                IServiceRegistrar instance = (IServiceRegistrar)Activator.CreateInstance(type);
                return instance;
            }
            return null;
        }
    }
}
