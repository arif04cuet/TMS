using Module.Core.Shared;

namespace Module.Asset.Data
{
    public class AssetLicenseListViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string ProductKey { get; set; }
    }
}
