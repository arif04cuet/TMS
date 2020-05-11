using Module.Core.Shared;

namespace Module.Asset.Data
{
    public class AssetComponentListViewModel : IViewModel
    {
        public long Id { get; set; }
        public IdNameViewModel Component { get; set; }
        public int Quantity { get; set; }
    }
}
