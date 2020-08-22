using Infrastructure.Entities;
using Module.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using Module.Core.Entities.Constants;
using Module.Training.Entities;
using System.Collections.Generic;

namespace Module.Asset.Entities
{
    [Table(nameof(RequisitionHistory), Schema = SchemaConstants.Asset)]
    public class RequisitionHistory : BaseEntity
    {

        public RequisitionHistory()
        {
            Items = new HashSet<RequisitionHistoryItem>();
        }

        public long? RequisitionId { get; set; }
        public Requisition Requisition { get; set; }

        public string Title { get; set; }
        public long InitiatorId { get; set; }
        public User Initiator { get; set; }

        public long? ApproverId { get; set; }
        public User Approver { get; set; }

        public long? RoleApproverId { get; set; }
        public Role RoleApprover { get; set; }

        public long? BatchScheduleId { get; set; }
        public BatchSchedule BatchSchedule { get; set; }

        public RequisitionStatus Status { get; set; }

        public virtual ICollection<RequisitionHistoryItem> Items { get; set; }

    }
}