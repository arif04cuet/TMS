using Module.Asset.Entities;
using Module.Core.Data;
using Module.Core.Shared;
using System;
using System.Linq.Expressions;

namespace Module.Asset.Data
{
    public class RequisitionListViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public long ItemCount { get; set; }
        public bool CanReject { get; set; }
        public bool CanApprove { get; set; }
        public bool CanTemporaryApprove { get; set; }
        //public IdNameViewModel Initiator { get; set; }
        //public IdNameViewModel CurrentApprover { get; set; }
        //public IdNameViewModel CurrentRoleApprover { get; set; }
        //public IdNameViewModel BatchSchedule { get; set; }
        public IdNameViewModel Status { get; set; }

        public static Expression<Func<Requisition, RequisitionListViewModel>> Select(long? loggedInUserId, long? loggedInUserRoleId)
        {
            return x => new RequisitionListViewModel
            {
                Id = x.Id,
                Title = x.Title,
                ItemCount = x.Items.Count,

                CanReject = ((x.CurrentApproverId == loggedInUserId && x.CurrentApproverId != null) || (x.CurrentRoleApproverId == loggedInUserRoleId && x.CurrentRoleApproverId != null))
                && x.Status == RequisitionStatus.Initiated,

                CanApprove = ((x.CurrentApproverId == loggedInUserId && x.CurrentApproverId != null) || (x.CurrentRoleApproverId == loggedInUserRoleId && x.CurrentRoleApproverId != null))
                && (x.Status == RequisitionStatus.Initiated || x.Status == RequisitionStatus.TemporaryApproved)
                && loggedInUserRoleId == RoleConstants.InventoryManager,

                CanTemporaryApprove = ((x.CurrentApproverId == loggedInUserId && x.CurrentApproverId != null) || (x.CurrentRoleApproverId == loggedInUserRoleId && x.CurrentRoleApproverId != null))
                && x.Status == RequisitionStatus.Initiated,

                //Initiator = new IdNameViewModel { Id = x.Initiator.Id, Name = x.Initiator.FullName },
                //BatchSchedule = x.BatchScheduleId.HasValue ? new IdNameViewModel { Id = x.BatchSchedule.Id, Name = x.BatchSchedule.Name } : null,
                //CurrentApprover = x.CurrentApproverId.HasValue ? new IdNameViewModel { Id = x.CurrentApprover.Id, Name = x.CurrentApprover.FullName } : null,
                //CurrentRoleApprover = x.CurrentRoleApproverId.HasValue ? new IdNameViewModel { Id = x.CurrentRoleApprover.Id, Name = x.CurrentRoleApprover.Name } : null,
                Status = new IdNameViewModel { Id = (long)x.Status, Name = x.Status.ToString() }
            };
        }

    }
}
