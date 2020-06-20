using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Module.Core.Shared
{
    public class ExcelService : IExcelService
    {

        public ExcelService()
        {
            //
        }

        public byte[] Generate<T>(IEnumerable<T> records)
        {
            using (var stream = new MemoryStream())
            {
                using (var streamWriter = new StreamWriter(stream))
                {
                    var csv = new CsvWriter(streamWriter, CultureInfo.InvariantCulture);
                    csv.WriteRecords(records);
                    streamWriter.Flush();
                    var _csv = stream.ToArray();
                    return _csv;
                }
            }
        }
    }
}
