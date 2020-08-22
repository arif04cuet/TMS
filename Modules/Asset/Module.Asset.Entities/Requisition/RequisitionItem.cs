using Infrastructure.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using Module.Core.Entities.Constants;

namespace Module.Asset.Entities
{
    [Table(nameof(RequisitionItem), Schema = SchemaConstants.Asset)]
    public class RequisitionItem : BaseEntity
    {
        public long RequisitionId { get; set; }
        public Requisition Requisition { get; set; }
        public long AssetId { get; set; }
        public AssetType AssetType { get; set; }
        public int Quantity { get; set; }
        public string Comment { get; set; }

    }
}