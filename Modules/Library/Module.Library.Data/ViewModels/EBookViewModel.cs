using Module.Core.Shared;
using System;

namespace Module.Library.Data
{
    public class EBookViewModel : IViewModel
    {
        public long Id { get; set; }
        public string FileName { get; set; }
        public bool IsDownloadable { get; set; }
    }
}
