using Module.Asset.Entities;
using Module.Core.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Module.Asset.Data
{
    public class RequisitionViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public IdNameViewModel Initiator { get; set; }
        public IdNameViewModel CurrentApprover { get; set; }
        public IdNameViewModel CurrentRoleApprover { get; set; }
        public IdNameViewModel BatchSchedule { get; set; }
        public IdNameViewModel Status { get; set; }
        public IEnumerable<RequisitionItemViewModel> Items { get; set; }
        public IEnumerable<RequisitionHistoryViewModel> Histories { get; set; }

        public static Expression<Func<Requisition, RequisitionViewModel>> Select()
        {
            return x => new RequisitionViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Initiator = new IdNameViewModel { Id = x.Initiator.Id, Name = x.Initiator.FullName },
                BatchSchedule = x.BatchScheduleId.HasValue ? new IdNameViewModel { Id = x.BatchSchedule.Id, Name = x.BatchSchedule.Name } : null,
                CurrentApprover = x.CurrentApproverId.HasValue ? new IdNameViewModel { Id = x.CurrentApprover.Id, Name = x.CurrentApprover.FullName } : null,
                CurrentRoleApprover = x.CurrentRoleApproverId.HasValue ? new IdNameViewModel { Id = x.CurrentRoleApprover.Id, Name = x.CurrentRoleApprover.Name } : null,
                Status = new IdNameViewModel { Id = (long)x.Status, Name = x.Status.ToString() },

                Items = x.Items.Select(y => new RequisitionItemViewModel
                {
                    Id = y.Id,
                    RequisitionId = y.RequisitionId,
                    Asset = new IdNameViewModel { Id = y.AssetId },
                    Quantity = y.Quantity,
                    Comment = y.Comment,
                    AssetType = new IdNameViewModel { Id = (long)y.AssetType, Name = y.AssetType.ToString() }
                }),

                Histories = x.Histories.Select(y => new RequisitionHistoryViewModel
                {
                    Id = y.Id,
                    RequisitionId = y.RequisitionId,
                    Title = y.Title,
                    Initiator = new IdNameViewModel { Id = y.Initiator.Id, Name = y.Initiator.FullName },
                    BatchSchedule = x.BatchScheduleId.HasValue ? new IdNameViewModel { Id = y.BatchSchedule.Id, Name = y.BatchSchedule.Name } : null,
                    Approver = y.ApproverId.HasValue ? new IdNameViewModel { Id = y.Approver.Id, Name = y.Approver.FullName } : null,
                    RoleApprover = y.RoleApproverId.HasValue ? new IdNameViewModel { Id = y.RoleApprover.Id, Name = y.RoleApprover.Name } : null,
                    Status = new IdNameViewModel { Id = (long)y.Status, Name = y.Status.ToString() },

                    Items = y.Items.Select(z => new RequisitionHistoryItemViewModel
                    {
                        Id = z.Id,
                        RequisitionId = z.RequisitionId,
                        RequisitionHistoryId = z.RequisitionHistoryId,
                        Asset = new IdNameViewModel { Id = z.AssetId },
                        AssetType = new IdNameViewModel { Id = (long)z.AssetType, Name = z.AssetType.ToString() },
                        RequestQuantity = z.Quantity,
                        Comment = z.Comment
                    })
                })
            };
        }

    }
}
