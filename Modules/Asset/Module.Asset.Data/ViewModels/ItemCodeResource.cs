using Module.Asset.Entities;

namespace Module.Asset.Data
{
    public class ItemCodeResource
    {
        public string Name { get; set; }

        public string Code { get; set; }

        public long CategoryId { get; set; }

        public int MinQuantity { get; set; }

        public bool IsActive { get; set; }


        public ItemCode ToMap(ItemCode item = null)
        {
            var entity = item ?? new ItemCode();

            entity.Name = Name;
            entity.Code = Code;
            entity.CategoryId = CategoryId;
            entity.MinQuantity = MinQuantity;
            entity.IsActive = IsActive;

            return entity;
        }
    }
}