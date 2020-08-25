using Module.Asset.Entities;
using Module.Core.Shared;
using System;
using System.Linq;
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
        public bool IsInventoryManager { get; set; }
        public IdNameViewModel Status { get; set; }
        public IdNameViewModel Initiator { get; set; }

        public static Expression<Func<Requisition, RequisitionListViewModel>> Select(long? loggedInUserId, long[] loggedInUserRoleIds, bool isInventoryManager)
        {
            return x => new RequisitionListViewModel
            {
                Id = x.Id,
                Title = x.Title,
                ItemCount = x.Items.Count,

                CanReject = ((x.CurrentApproverId == loggedInUserId && x.CurrentApproverId != null) || (loggedInUserRoleIds.Contains(x.CurrentRoleApproverId.Value) && x.CurrentRoleApproverId != null))
                && (x.Status == RequisitionStatus.Initiated || x.Status == RequisitionStatus.TemporaryApproved),

                CanApprove = ((x.CurrentApproverId == loggedInUserId && x.CurrentApproverId != null) || (loggedInUserRoleIds.Contains(x.CurrentRoleApproverId.Value) && x.CurrentRoleApproverId != null))
                && (x.Status == RequisitionStatus.Initiated || x.Status == RequisitionStatus.TemporaryApproved)
                && isInventoryManager,

                CanTemporaryApprove = ((x.CurrentApproverId == loggedInUserId && x.CurrentApproverId != null) || (loggedInUserRoleIds.Contains(x.CurrentRoleApproverId.Value) && x.CurrentRoleApproverId != null))
                && x.Status == RequisitionStatus.Initiated,

                IsInventoryManager = isInventoryManager,

                Status = new IdNameViewModel { Id = (long)x.Status, Name = x.Status.ToString() },
                Initiator = new IdNameViewModel { Id = x.Initiator.Id, Name = x.Initiator.FullName }
            };
        }

    }
}
