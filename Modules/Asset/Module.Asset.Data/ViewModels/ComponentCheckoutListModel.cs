using Module.Core.Shared;

namespace Module.Asset.Data
{
    public class ComponentCheckoutListModel : IViewModel
    {
        public long Id { get; set; }
        public long ComponentId { get; set; }
        public IdNameViewModel User { get; set; }
    }
}
