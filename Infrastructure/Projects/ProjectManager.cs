using Infrastructure.Data;
using Infrastructure.Entities;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Infrastructure
{
    public static class ProjectManager
    {
        private static ConcurrentDictionary<Type, IEnumerable<Type>> cachedTypes;

        public static string Env { get; set; }
        public static string StoragePath { get; set; }
        public static IEnumerable<Assembly> Assemblies { get; private set; }
        public static List<IServiceRegistrar> ServiceRegistrars { get; private set; }
        public static List<Type> Entities { get; private set; }

        public static List<ISeedProvider<IEntity>> SeedProviders { get; private set; }

        public static void SetSeedProviders(List<ISeedProvider<IEntity>> seedProviders)
        {
            SeedProviders = seedProviders;
        }

        public static void SetEntities(List<Type> entities)
        {
            Entities = entities;
        }

        public static void SetServiceRegistrars(List<IServiceRegistrar> serviceRegistrars)
        {
            ServiceRegistrars = serviceRegistrars;
        }

        public static void SetAssemblies(IEnumerable<Assembly> assemblies)
        {
            Assemblies = assemblies;
            cachedTypes = new ConcurrentDictionary<Type, IEnumerable<Type>>();
        }

        public static Type GetImplementation<T>(bool useCaching = false)
        {
            return GetImplementation<T>(null, useCaching);
        }

        public static Type GetImplementation<T>(Func<Assembly, bool> predicate, bool useCaching = false)
        {
            return GetImplementations<T>(predicate, useCaching).FirstOrDefault();
        }

        public static IEnumerable<Type> GetImplementations<T>(bool useCaching = false)
        {
            return GetImplementations<T>(null, useCaching);
        }

        public static IEnumerable<Type> GetGenericImplementations(Type type, Func<Assembly, bool> predicate, bool useCaching = false)
        {

            if (useCaching && cachedTypes.ContainsKey(type))
            {
                return cachedTypes[type];
            }

            List<Type> implementations = new List<Type>();

            var assemblies = GetAssemblies(predicate);
            foreach (Assembly assembly in assemblies)
            {
                var exportedTypes = assembly.GetExportedTypes();
                foreach (Type exportedType in exportedTypes)
                {
                    var interfaces = exportedType.GetInterfaces().Where(x => x.IsGenericType);
                    foreach (var @interface in interfaces)
                    {
                        if (@interface.GetGenericTypeDefinition() == type)
                        {
                            implementations.Add(exportedType);
                        }
                    }
                }
            }

            if (useCaching)
            {
                cachedTypes[type] = implementations;
            }

            return implementations;
        }

        public static IEnumerable<Type> GetImplementations<T>(Func<Assembly, bool> predicate, bool useCaching = false)
        {
            Type type = typeof(T);

            if (useCaching && cachedTypes.ContainsKey(type))
            {
                return cachedTypes[type];
            }

            List<Type> implementations = new List<Type>();

            var assemblies = GetAssemblies(predicate);
            foreach (Assembly assembly in assemblies)
            {
                var exportedTypes = assembly.GetExportedTypes();
                foreach (Type exportedType in exportedTypes)
                {
                    if (type.GetTypeInfo().IsAssignableFrom(exportedType) && exportedType.GetTypeInfo().IsClass)
                    {
                        implementations.Add(exportedType);
                    }
                }
            }

            if (useCaching)
            {
                cachedTypes[type] = implementations;
            }

            return implementations;
        }

        public static T GetInstance<T>(bool useCaching = false)
        {
            return GetInstance<T>(null, useCaching, new object[] { });
        }

        public static T GetInstance<T>(bool useCaching = false, params object[] args)
        {
            return GetInstance<T>(null, useCaching, args);
        }

        public static T GetInstance<T>(Func<Assembly, bool> predicate, bool useCaching = false)
        {
            return GetInstances<T>(predicate, useCaching).FirstOrDefault();
        }

        public static T GetInstance<T>(Func<Assembly, bool> predicate, bool useCaching = false, params object[] args)
        {
            return GetInstances<T>(predicate, useCaching, args).FirstOrDefault();
        }

        public static IEnumerable<T> GetInstances<T>(bool useCaching = false)
        {
            return GetInstances<T>(null, useCaching, new object[] { });
        }

        public static IEnumerable<T> GetInstances<T>(bool useCaching = false, params object[] args)
        {
            return GetInstances<T>(null, useCaching, args);
        }

        public static IEnumerable<T> GetInstances<T>(Func<Assembly, bool> predicate, bool useCaching = false)
        {
            return GetInstances<T>(predicate, useCaching, new object[] { });
        }

        public static IEnumerable<T> GetInstances<T>(Func<Assembly, bool> predicate, bool useCaching = false, params object[] args)
        {
            List<T> instances = new List<T>();
            var implementations = GetImplementations<T>(predicate, useCaching);
            foreach (Type implementation in implementations)
            {
                if (!implementation.GetTypeInfo().IsAbstract)
                {
                    T instance = (T)Activator.CreateInstance(implementation, args);
                    instances.Add(instance);
                }
            }
            return instances;
        }

        private static IEnumerable<Assembly> GetAssemblies(Func<Assembly, bool> predicate)
        {
            if (predicate == null)
            {
                return Assemblies;
            }
            return Assemblies.Where(predicate);
        }
    }

}
