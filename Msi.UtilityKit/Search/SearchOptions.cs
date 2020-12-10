namespace Msi.UtilityKit.Search
{
    public class SearchOptions : ISearchOptions
    {
        public string[] Search { get; set; }

        public string ToSqlSyntax(string properyPrefix = "")
        {
            string where = "";
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
                        if (@operator == "like")
                        {
                            where += $" {properyPrefix}{propertyName} like '{value}%'";
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
                                value = $"'{value}'";
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
