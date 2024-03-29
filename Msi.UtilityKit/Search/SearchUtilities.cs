﻿using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Msi.UtilityKit.Search
{
    public static class SearchUtilities
    {

        private static SearchUtilitiesOptions _utilitiesOptions;
        private static IComparisonExpressionProviderFactory _comparisonExpressionProviderFactory;

        public static IQueryable<T> ApplySearch<T>(this IQueryable<T> query, ISearchOptions options)
        {

            if (options?.Search?.Length > 0)
            {

                if (_utilitiesOptions == null)
                {
                    _utilitiesOptions = SearchUtilitiesOptions.DefaultOptions;
                    _comparisonExpressionProviderFactory = _utilitiesOptions.ComparisonExpressionProviderFactory;
                }

                var _searchQuery = options.Search;
                var searchQueryLength = _searchQuery.Length;

                // get given type's all properties
                var properties = typeof(T).GetProperties();
                var propertiesLength = properties.Length;

                // iterate over all terms
                for (int i = 0; i < searchQueryLength; i++)
                {

                    if (string.IsNullOrEmpty(_searchQuery[i])) continue;

                    // expression -> name eq shahid
                    var tokens = _searchQuery[i].Split(' ');
                    if (tokens.Length >= 3)
                    {
                        string @operator = tokens[1];
                        string value = tokens.Skip(2).Join(" ").Trim();
                        if (!string.IsNullOrWhiteSpace(value))
                        {
                            for (int j = 0; j < propertiesLength; j++)
                            {
                                var property = properties[j];

                                // if property has searchable attribute and search term equals to property name
                                var searchableAttribute = properties[j].GetCustomAttributes<SearchableAttribute>().FirstOrDefault();
                                var tokenParts = tokens[0].Split('.');
                                bool isSearchable = searchableAttribute != null && properties[j].Name.Equals(tokenParts[0], StringComparison.OrdinalIgnoreCase);

                                if (isSearchable)
                                {
                                    // build up the LINQ expression backwards:
                                    // query = query.Where(x => x.Property == "Value");

                                    var parameter = ExpressionUtilities.Parameter<T>();

                                    // x.Property
                                    var left = parameter.GetPropertyExpression(property);

                                    if (tokenParts.Length > 1)
                                    {
                                        left = tokenParts.Skip(1).Aggregate(left, Expression.Property);
                                    }

                                    // "Value"
                                    var propertyType = property.GetSafePropertyType();

                                    if (tokenParts.Length > 1)
                                    {
                                        foreach (var tokenPart in tokenParts.Skip(1))
                                        {
                                            property = propertyType.GetProperty(tokenPart);
                                            propertyType = property.GetSafePropertyType();
                                        }
                                    }

                                    object constantValue = null;
                                    if (propertyType.IsEnum)
                                    {
                                        constantValue = Enum.Parse(propertyType, value);
                                    }
                                    else
                                    {
                                        if (!value.Equals("NULL"))
                                        {
                                            constantValue = Convert.ChangeType(value, propertyType);
                                        }
                                    }

                                    var right = Expression.Constant(constantValue, property.PropertyType);

                                    // x.Property == "Value"
                                    var comparisonExpressionProvider = _comparisonExpressionProviderFactory.CreateProvider(@operator.ToLower());
                                    var comparisonExpression = comparisonExpressionProvider.GetExpression(left, right);

                                    // x => x.Property == "Value"
                                    var lambda = ExpressionUtilities
                                        .GetLambda<T, bool>(parameter, comparisonExpression);

                                    // query = query.Where...
                                    query = query.DynamicWhere(lambda);

                                }
                            }
                        }
                    }
                }
            }
            return query;
        }

        public static void Configure(Action<SearchUtilitiesOptions> options)
        {
            _utilitiesOptions = new SearchUtilitiesOptions();
            options.Invoke(_utilitiesOptions);
        }

        public static Type GetSafePropertyType(this PropertyInfo propertyInfo)
        {
            return Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
        }

    }
}
