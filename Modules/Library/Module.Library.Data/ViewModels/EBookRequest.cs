using Module.Library.Entities;
using System;

namespace Module.Library.Data
{
    public class EBookRequest
    {
        public long Media { get; set; }
        public bool IsDownloadable { get; set; }
        public long Format { get; set; }

        public EBook ToEBook()
        {
            return new EBook
            {
                MediaId = Media,
                IsDownloadable = IsDownloadable,
                FormatId = Format
            };
        }
    }
}
