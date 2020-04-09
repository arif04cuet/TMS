using System.Collections.Generic;

namespace Msi.UtilityKit
{
    public static class ORMUtilities
    {

        public static string GenerateInsertSql(this object entity)
        {

            var type = entity.GetType();
            var properties = type.GetProperties();
            var propertiesLength = properties.Count();

            var columns = new List<string>();
            var values = new List<string>();

            for (int i = 0; i < propertiesLength; i++)
            {
                var property = properties[i];
                if (property.PropertyType.IsSimpleType())
                {
                    columns.Add(property.Name);
                    if (property.PropertyType == typeof(string))
                    {
                        var value = property.GetValue(entity);
                        values.Add(value == null ? "null" : $"'{value.ToString()}'");
                    }
                    else
                    {
                        var value = property.GetValue(entity);
                        values.Add(value == null ? "null" : value.ToString());
                    }
                }
            }
            var columnsString = columns.Join(", ");
            var valuesString = values.Join(", ");
            return $"INSERT INTO {type.Name}({columnsString}) VALUES ({valuesString})";
        }

        public static string GenerateUpdateSql(this object entity)
        {
            var type = entity.GetType();
            var properties = type.GetProperties();
            var propertiesLength = properties.Count();

            var columnValues = new List<string>();
            object id = null;

            for (int i = 0; i < propertiesLength; i++)
            {
                var property = properties[i];
                if (property.PropertyType.IsSimpleType())
                {
                    if (id == null)
                    {
                        id = property.Name.ToLower() == "id" ? property.GetValue(entity) : null;
                    }
                    string columnValue = $"{property.Name} = ";
                    if (property.PropertyType == typeof(string))
                    {
                        var value = property.GetValue(entity);
                        columnValue += value == null ? "null" : $"'{value.ToString()}'";
                    }
                    else
                    {
                        var value = property.GetValue(entity);
                        columnValue += value == null ? "null" : value.ToString();
                    }
                    columnValues.Add(columnValue);
                }
            }
            var columnValuesString = columnValues.Join(", ");
            return $"UPDATE {type.Name} SET {columnValuesString} WHERE Id = {id}";
        }

        public static string GenerateDeleteSql(this object entity)
        {
            var type = entity.GetType();
            var properties = type.GetProperties();
            var propertiesLength = properties.Count();
            var columnValues = new List<string>();
            object id = null;
            for (int i = 0; i < propertiesLength; i++)
            {
                var property = properties[i];
                if (id == null)
                {
                    id = property.Name.ToLower() == "id" ? property.GetValue(entity) : null;
                    break;
                }
            }
            return $"DELETE FROM {type.Name} WHERE Id = {id}";
        }

    }
}
