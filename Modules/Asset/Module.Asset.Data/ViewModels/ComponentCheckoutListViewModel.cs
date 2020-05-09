using Module.Core.Shared;

namespace Module.Asset.Data
{
    public class ComponentCheckoutListViewModel : IViewModel
    {
        public long Id { get; set; }
        public long ComponentId { get; set; }
        public int Quantity { get; set; }
        public IdNameViewModel Asset { get; set; }
    }
}
