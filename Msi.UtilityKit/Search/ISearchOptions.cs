namespace Msi.UtilityKit.Search
{
    public interface ISearchOptions
    {
        string[] Search { get; set; }

        string ToSqlSyntax(string properyPrefix = "");
    }
}
