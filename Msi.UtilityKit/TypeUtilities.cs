﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Msi.UtilityKit
{
    public static class TypeUtilities
    {

        /// <summary>
        /// Find a type by name where reference type is located. T =  ReferenceType
        /// </summary>
        public static Type FindTypeByName<T>(string name)
        {
            return FindTypeByName(typeof(T).Assembly, name);
        }

        public static Type FindTypeByName(Assembly assembly, string name)
        {
            Type[] types = assembly.GetTypes();
            int typeCount = types.Length;
            for (int i = 0; i < typeCount; i++)
            {
                var type = types[i];
                if (type.IsClass && !type.IsAbstract && type.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                {
                    return type;
                }
            }
            return default(Type);
        }

        /// <summary>
        /// Determine whether a type is simple (ValueType, Primitive, String, Decimal, DateTime, DateTimeOffset, TimeSpan, Guid etc).
        /// </summary>
        public static bool IsSimpleType(
            this Type type)
        {
            return
                type.IsValueType ||
                type.IsPrimitive ||
                new Type[] {
                typeof(String),
                typeof(Decimal),
                typeof(DateTime),
                typeof(DateTimeOffset),
                typeof(TimeSpan),
                typeof(Guid)
                }.Contains(type) ||
                Convert.GetTypeCode(type) != TypeCode.Object;
        }

        public static bool IsSimpleType<T>(this T type)
        {
            return type.GetType().IsSimpleType();
        }

        public static bool IsCollectionType(this Type type)
        {
            // string implements IEnumerable<char>
            if (type == null || type == typeof(string))
            {
                return false;
            }
            return IsEnumerable(type) || type.GetInterfaces().Any(IsEnumerable);
        }

        public static bool IsCollectionType<T>(this T type)
        {
            return type.GetType().IsCollectionType();
        }

        public static bool IsEnumerable(this Type type)
        {
            return type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>);
        }

        public static bool IEnumerable<T>(this T type)
        {
            return type.GetType().IsEnumerable();
        }

        public static T CastTo<T>(this object source)
        {
            return (T)source;
        }

        public static bool IsNullable<T>(this T type)
        {
            return Nullable.GetUnderlyingType(type.GetType()) != null;
        }

        /// <summary>
        /// Callback's first argument is interface and second argument is implemented type
        /// </summary>
        public static void FindTypesImplementedByGenericInterface(Assembly assembly, Type genericInterfaceType, Action<Type, Type> callback = null)
        {
            foreach (var type in assembly.ExportedTypes)
            {
                if (type.IsClass && !type.IsAbstract)
                {
                    var typeInfo = type.GetTypeInfo();
                    foreach (var typeInterface in typeInfo.ImplementedInterfaces)
                    {
                        var typeInterfaceTypeInfo = typeInterface.GetTypeInfo();
                        if (typeInterfaceTypeInfo.IsGenericType && typeInterfaceTypeInfo.GetGenericTypeDefinition() == genericInterfaceType)
                        {
                            callback?.Invoke(typeInterfaceTypeInfo.AsType(), typeInfo.AsType());
                        }
                    }
                }
            }
        }

        public static void Scan(IEnumerable<Assembly> assemblies, Action<TypeInfo> config)
        {
            foreach (var assembly in assemblies)
            {
                var classTypes = assembly.ExportedTypes.Select(t => t.GetTypeInfo()).Where(t => t.IsClass && !t.IsAbstract);

                foreach (var type in classTypes)
                {
                    config?.Invoke(type);
                }
            }
        }

        /// <summary>
        /// Checks whether <paramref name="givenType"/> implements/inherits <paramref name="genericType"/>.
        /// </summary>
        /// <param name="givenType">Type to check</param>
        /// <param name="genericType">Generic type</param>
        public static bool IsAssignableToGenericType(Type givenType, Type genericType)
        {
            var givenTypeInfo = givenType.GetTypeInfo();

            if (givenTypeInfo.IsGenericType && givenType.GetGenericTypeDefinition() == genericType)
            {
                return true;
            }

            foreach (var interfaceType in givenTypeInfo.GetInterfaces())
            {
                if (interfaceType.GetTypeInfo().IsGenericType && interfaceType.GetGenericTypeDefinition() == genericType)
                {
                    return true;
                }
            }

            if (givenTypeInfo.BaseType == null)
            {
                return false;
            }

            return IsAssignableToGenericType(givenTypeInfo.BaseType, genericType);
        }

    }
}
