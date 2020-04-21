using Infrastructure.Entities;
using Msi.UtilityKit.Search;

namespace Module.Asset.Entities
{
    public enum MasterStatus
    {
        Deployable = 1,
        Pending = 2,
        Undeployable = 3,
        Archived = 4
    }


    public class Status : BaseEntity
    {
        [Searchable]
        public string Name { get; set; }

        [Searchable]
        public MasterStatus Type { get; set; }

        public string Color { get; set; }
        public string Note { get; set; }


    }
}