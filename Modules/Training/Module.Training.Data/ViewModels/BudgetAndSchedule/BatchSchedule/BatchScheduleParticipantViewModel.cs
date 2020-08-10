using Module.Core.Shared;
using Module.Training.Entities;
using System;
using System.Linq.Expressions;

namespace Module.Training.Data
{
    public class BatchScheduleParticipantViewModel
    {
        public long Id { get; set; }
        public long BatchScheduleAllocationId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }
        public IdNameViewModel Designation { get; set; }

        public static Expression<Func<BatchScheduleAllocation, BatchScheduleParticipantViewModel>> Select()
        {
            return x => new BatchScheduleParticipantViewModel
            {
                Id = x.Trainee.Id,
                BatchScheduleAllocationId = x.Id,
                Name = x.Trainee.FullName,
                Email = x.Trainee.Email,
                Status = x.Status.ToString(),
                Designation = x.Trainee.DesignationId != null ? new IdNameViewModel
                {
                    Id = x.Trainee.DesignationId.Value,
                    Name = x.Trainee.Designation.Name
                } : null
            };
        }
    }
}
