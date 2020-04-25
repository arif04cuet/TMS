using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using Msi.UtilityKit.Search;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Asset.Entities
{
    [Table(nameof(Vendor), Schema = SchemaConstants.Asset)]
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

        [Searchable]
        public long? StatusId { get; set; }
        public Status Status { get; set; }

    }
}
