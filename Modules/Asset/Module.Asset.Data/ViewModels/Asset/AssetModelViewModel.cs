using Module.Core.Shared;

namespace Module.Asset.Data
{
    public class AssetModelViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ModelNo { get; set; }
        public int Eol { get; set; }
        public string Note { get; set; }
        public IdNameViewModel Category { get; set; }
        public IdNameViewModel Manufacturer { get; set; }
        public IdNameViewModel Depreciation { get; set; }
        public bool IsRequestable { get; set; }
        public string Photo { get; set; }
    }
}
