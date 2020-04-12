using Infrastructure.Entities;
using Module.Core.Entities;
using Msi.UtilityKit.Search;

namespace Module.Asset.Entities
{
    public class Vendor : BaseEntity
    {
        [Searchable]
        public string VendorName { get; set; }

        [Searchable]
        public string VendorEmail { get; set; }

        [Searchable]
        public string AccountManagerName { get; set; }

        [Searchable]
        public string AccountManagerPhone { get; set; }

        public long? StatusId { get; set; }
        public Status Status { get; set; }

    }
}
