using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Infrastructure.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceRegistrar AddServices(this IServiceCollection services, TypeInfo typeInfo)
        {
            var interfaces = typeInfo.ImplementedInterfaces.Select(i => i.GetTypeInfo());

            services.AddService(nameof(ITransientService), interfaces, typeInfo, ServiceLifetime.Transient);

            services.AddService(nameof(ISingletonService), interfaces, typeInfo, ServiceLifetime.Singleton);

            services.AddService(nameof(IScopedService), interfaces, typeInfo, ServiceLifetime.Scoped);

            services.AddService(nameof(IService), interfaces, typeInfo, ServiceLifetime.Transient);
            return null;
        }

        private static void AddService(this IServiceCollection services, string service, IEnumerable<TypeInfo> interfaces, TypeInfo implementation, ServiceLifetime lifetime)
        {
            foreach (var handlerTypeInfo in interfaces.Where(x => x.GetInterface(service) != null))
            {
                var descriptor = new ServiceDescriptor(handlerTypeInfo.AsType(), implementation.AsType(), lifetime);
                services.Add(descriptor);
            }
        }
    }
}
