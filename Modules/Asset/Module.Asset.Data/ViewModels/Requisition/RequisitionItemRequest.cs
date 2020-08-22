using Module.Asset.Entities;

namespace Module.Asset.Data
{
    public class RequisitionItemRequest
    {
        public long? Id { get; set; }
        public long Asset { get; set; }
        public AssetType Type { get; set; }
        public int Quantity { get; set; }
        public string Comment { get; set; }

        public RequisitionItem Map(RequisitionItem entity = null)
        {
            entity = entity ?? new RequisitionItem();
            entity.AssetId = Asset;
            entity.AssetType = Type;
            entity.Comment = Comment;
            entity.Quantity = Quantity;
            return entity;
        }
    }
}
