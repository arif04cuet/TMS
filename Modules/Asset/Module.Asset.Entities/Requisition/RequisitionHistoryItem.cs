using Infrastructure.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using Module.Core.Entities.Constants;

namespace Module.Asset.Entities
{
    [Table(nameof(RequisitionHistoryItem), Schema = SchemaConstants.Asset)]
    public class RequisitionHistoryItem : BaseEntity
    {
        public long? RequisitionId { get; set; }
        public Requisition Requisition { get; set; }
        public long RequisitionHistoryId { get; set; }
        public RequisitionHistory RequisitionHistory { get; set; }
        public long AssetId { get; set; }
        public AssetType AssetType { get; set; }
        public int Quantity { get; set; }
        public string Comment { get; set; }

    }
}