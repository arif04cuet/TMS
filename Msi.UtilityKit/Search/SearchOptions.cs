using System;

namespace Msi.UtilityKit.Search
{
    public class SearchOptions : ISearchOptions
    {
        public string[] Search { get; set; }

        public string ToSqlSyntax(Func<string, int, string> func)
        {
            string where = "";
            string properyPrefix = "";
            if (this.Search?.Length > 0)
            {
                int len = this.Search.Length;
                int c = 0;
                foreach (var item in this.Search)
                {
                    string[] parts = item.Split(' ');
                    if (parts.Length >= 3)
                    {
                        if (c != 0)
                        {
                            where += " and";
                        }
                        string propertyName = parts[0];
                        string @operator = parts[1];
                        string value = parts[2];
                        if(func != null)
                        {
                            properyPrefix = func(propertyName, c);
                            if(properyPrefix.Length > 0)
                            {
                                if(properyPrefix[0] == '#')
                                {
                                    var arr = properyPrefix.Split('.');
                                    if(arr.Length > 1)
                                    {
                                        properyPrefix = arr[0].Substring(1) + ".";
                                        propertyName = arr[1];
                                    }
                                }
                            }
                        }
                        propertyName = propertyName ?? "";
                        if (@operator == "like")
                        {
                            where += $" {properyPrefix}{propertyName} like N'{value}%'";
                        }
                        else if (@operator == "eq")
                        {
                            string lower = value.ToLower();
                            if(lower == "true")
                            {
                                value = "1";
                            }
                            else if (lower == "false")
                            {
                                value = "0";
                            }
                            else
                            {
                                value = $"N'{value}'";
                            }
                            where += $" {properyPrefix}{propertyName} = {value}";
                        }
                        c++;
                    }
                }
            }
            return where;
        }
    }
}
