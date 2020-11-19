
using Module.Asset.Entities;
using Module.Core.Shared;

namespace Module.Asset.Data
{
    public class ItemCodeByCategoryViewModel : IViewModel
    {

        public long Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public long CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int? Available { get; set; }
        public int MinQuantity { get; set; }
        public int? TotalQuantity { get; set; }
        public bool IsActive { get; set; }

    }
}
