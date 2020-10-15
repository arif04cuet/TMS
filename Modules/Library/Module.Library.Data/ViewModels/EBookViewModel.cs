using Module.Core.Shared;
using System;

namespace Module.Library.Data
{
    public class EBookViewModel : IViewModel
    {
        public long Id { get; set; }
        public string FileName { get; set; }
        public long? EBook { get; set; }
        public string FileName2 { get; set; }
        public long? EBook2 { get; set; }
        public bool IsDownloadable { get; set; }
    }
}
