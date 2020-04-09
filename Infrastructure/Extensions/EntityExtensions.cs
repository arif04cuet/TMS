using Infrastructure.Entities;
using System;
using System.Linq;
using System.Reflection;

namespace Infrastructure.Extensions
{
    public static class EntityExtensions
    {
        public static bool IsEntity(this Type type)
        {
            if (typeof(IEntity).GetTypeInfo().IsAssignableFrom(type))
            {
                if (!type.CustomAttributes.Any(x => x.AttributeType == typeof(IgnoredEntityAttribute)))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
