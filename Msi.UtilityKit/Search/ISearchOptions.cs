using System;

namespace Msi.UtilityKit.Search
{
    public interface ISearchOptions
    {
        string[] Search { get; set; }

        string ToSqlSyntax(Func<string, int ,string> func = null);
    }
}
