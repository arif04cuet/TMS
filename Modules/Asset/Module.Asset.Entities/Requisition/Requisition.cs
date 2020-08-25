using Infrastructure.Entities;
using Module.Core.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using Module.Core.Entities.Constants;
using Module.Training.Entities;
using System.Collections.Generic;
using Msi.UtilityKit.Search;

namespace Module.Asset.Entities
{
    [Table(nameof(Requisition), Schema = SchemaConstants.Asset)]
    public class Requisition : BaseEntity
    {

        public Requisition()
        {
            Items = new HashSet<RequisitionItem>();
            Histories = new HashSet<RequisitionHistory>();
        }

        [Searchable]
        public string Title { get; set; }
        public long InitiatorId { get; set; }
        public User Initiator { get; set; }

        public long? CurrentApproverId { get; set; }
        public User CurrentApprover { get; set; }

        public long? CurrentRoleApproverId { get; set; }
        public Role CurrentRoleApprover { get; set; }

        public long? BatchScheduleId { get; set; }
        public BatchSchedule BatchSchedule { get; set; }

        [Searchable]
        public RequisitionStatus Status { get; set; }

        public virtual ICollection<RequisitionItem> Items { get; set; }

        public virtual ICollection<RequisitionHistory> Histories { get; set; }

        public static RequisitionHistory MapHistory(Requisition entity)
        {
            return new RequisitionHistory
            {
                RequisitionId = entity.Id,
                InitiatorId = entity.InitiatorId,
                BatchScheduleId = entity.BatchScheduleId,
                ApproverId = entity.CurrentApproverId,
                RoleApproverId = entity.CurrentRoleApproverId,
                Status = entity.Status,
                Title = entity.Title
            };
        }

    }
}