using Module.Asset.Entities;
using System.Collections.Generic;

namespace Module.Asset.Data
{
    public class RequisitionStatusChangeRequest
    {
        public long Requisition { get; set; }
        public RequisitionStatus Status { get; set; }
        public IEnumerable<RequisitionItemRequest> Items { get; set; }
    }
}
