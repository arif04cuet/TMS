using Module.Core.Shared;

namespace Module.Asset.Data
{
    public class AssetItemCodeViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
    }
}
