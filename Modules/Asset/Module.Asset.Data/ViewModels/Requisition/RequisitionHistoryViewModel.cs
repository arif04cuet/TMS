using Module.Asset.Entities;
using Module.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Module.Asset.Data
{
    public class RequisitionHistoryViewModel
    {
        public long Id { get; set; }
        public long? RequisitionId { get; set; }
        public string Title { get; set; }
        public IdNameViewModel Initiator { get; set; }
        public IdNameViewModel Approver { get; set; }
        public IdNameViewModel RoleApprover { get; set; }
        public IdNameViewModel BatchSchedule { get; set; }
        public IdNameViewModel Status { get; set; }

        public IEnumerable<RequisitionHistoryItemViewModel> Items { get; set; }

        public static Expression<Func<RequisitionHistory, RequisitionHistoryViewModel>> Select()
        {
            return x => new RequisitionHistoryViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Initiator = new IdNameViewModel { Id = x.Initiator.Id, Name = x.Initiator.FullName },
                BatchSchedule = x.BatchScheduleId.HasValue ? new IdNameViewModel { Id = x.BatchSchedule.Id, Name = x.BatchSchedule.Name } : null,
                Approver = x.ApproverId.HasValue ? new IdNameViewModel { Id = x.Approver.Id, Name = x.Approver.FullName } : null,
                RoleApprover = x.RoleApproverId.HasValue ? new IdNameViewModel { Id = x.RoleApprover.Id, Name = x.RoleApprover.Name } : null,
                Status = new IdNameViewModel { Id = (long)x.Status, Name = x.Status.ToString() }
            };
        }

    }
}
