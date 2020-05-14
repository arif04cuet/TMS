
using Module.Asset.Entities;
using Module.Core.Shared;

namespace Module.Asset.Data
{
    public class ItemCodeViewModel : ItemCodeResource
    {

        public long Id { get; set; }
        public virtual Category Category { get; set; }
    }
}
