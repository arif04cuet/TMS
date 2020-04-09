using Infrastructure.Data;
using Infrastructure.Entities;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Infrastructure.Extensions
{
    public static class ModuleExtensions
    {

        public static IServiceCollection AddModules(this IServiceCollection services)
        {
            var assemblyProvider = new AssemblyProvider(services.BuildServiceProvider());
            ProjectManager.SetAssemblies(assemblyProvider.GetAssemblies(null, false));

            var classTypes = ProjectManager.Assemblies
                    .SelectMany(x => x.ExportedTypes)
                    .Select(t => t.GetTypeInfo())
                    .Where(t => t.IsClass && !t.IsAbstract);

            List<Type> _entities = new List<Type>();
            List<IServiceRegistrar> _serviceRegistrars = new List<IServiceRegistrar>();
            List<ISeedProvider<IEntity>> _seedProviders = new List<ISeedProvider<IEntity>>();

            foreach (var implementationTypeInfo in classTypes)
            {
                var implementationType = implementationTypeInfo.AsType();

                if (implementationType.IsEntity())
                    _entities.Add(implementationType);

                IServiceRegistrar serviceRegistrar = implementationType.GetServiceRegistrar();
                if (serviceRegistrar != null)
                    _serviceRegistrars.Add(serviceRegistrar);

                ISeedProvider<IEntity> seedProvider = implementationType.GetSeedProvider();
                if (seedProvider != null)
                    _seedProviders.Add(seedProvider);

                services.AddServices(implementationTypeInfo);

            }

            ProjectManager.SetEntities(_entities);
            ProjectManager.SetServiceRegistrars(_serviceRegistrars);
            ProjectManager.SetSeedProviders(_seedProviders.OrderBy(x => x.Order).ToList());

            return services;
        }

    }
}
