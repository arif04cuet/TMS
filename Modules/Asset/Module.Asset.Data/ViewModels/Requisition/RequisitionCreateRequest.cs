using Module.Asset.Entities;
using System.Collections.Generic;

namespace Module.Asset.Data
{
    public class RequisitionCreateRequest
    {
        public string Title { get; set; }
        public long Initiator { get; set; }
        public long? CurrentApprover { get; set; }
        public long? BatchSchedule { get; set; }
        public IEnumerable<RequisitionItemRequest> Items { get; set; }

        public Requisition Map(Requisition entity = null)
        {
            entity = entity ?? new Requisition();
            entity.Title = Title;
            entity.BatchScheduleId = BatchSchedule;
            entity.CurrentApproverId = CurrentApprover;
            return entity;
        }
    }
}
