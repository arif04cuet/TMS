using Infrastructure;
using System.Collections.Generic;

namespace Module.Core.Shared
{
    public interface IExcelService : IScopedService
    {
        byte[] Generate<T>(IEnumerable<T> records);
    }
}
