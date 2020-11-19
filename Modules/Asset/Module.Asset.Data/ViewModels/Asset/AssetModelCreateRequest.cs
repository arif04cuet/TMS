using Module.Asset.Entities;

namespace Module.Asset.Data
{
    public class AssetModelCreateRequest
    {
        public string Name { get; set; }
        public string ModelNo { get; set; }

        public string Note { get; set; }
        public long Category { get; set; }
        public long? Manufacturer { get; set; }

        public bool IsRequestable { get; set; }
        public long? Media { get; set; }

        public AssetModel ToMap(AssetModel asset = null)
        {
            var entity = asset ?? new AssetModel();
            entity.CategoryId = Category;
            entity.IsRequestable = IsRequestable;
            entity.ManufacturerId = Manufacturer;
            entity.ModelNo = ModelNo;
            entity.MediaId = Media;
            entity.Name = Name;
            entity.Note = Note;

            return entity;
        }
    }
}
