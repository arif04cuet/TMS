using Infrastructure.Data;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Extensions
{
    public static class SeedProviderExtensions
    {

        private static Type seedProviderType = typeof(ISeedProvider<>);

        public static ISeedProvider<IEntity> GetSeedProvider(this Type type)
        {
            var interfaces = type.GetInterfaces().Where(x => x.IsGenericType);
            foreach (var @interface in interfaces)
            {
                if (@interface.GetGenericTypeDefinition() == seedProviderType)
                {
                    var args = @interface.GetGenericArguments();
                    foreach (var arg in args)
                    {
                        ISeedProvider<IEntity> instance = (ISeedProvider<IEntity>)Activator.CreateInstance(type);
                        return instance;
                    }
                }
            }
            return null;
        }

    }
}
