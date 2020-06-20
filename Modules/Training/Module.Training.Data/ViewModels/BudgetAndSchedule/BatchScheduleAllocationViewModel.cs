using Module.Core.Shared;
using Module.Training.Entities;
using System;
using System.Linq.Expressions;

namespace Module.Training.Data
{
    public class BatchScheduleAllocationViewModel
    {
        public long Id { get; set; }
        public IdNameViewModel BatchSchedule { get; set; }
        public IdNameViewModel Course { get; set; }
        // User
        public IdNameViewModel Trainee { get; set; }
        public DateTime AppliedDate { get; set; }
        public DateTime? AllocationDate { get; set; }

        public IdNameViewModel Status { get; set; }

        public static Expression<Func<BatchScheduleAllocation, BatchScheduleAllocationViewModel>> Select()
        {
            return x => new BatchScheduleAllocationViewModel
            {
                Id = x.Id,
                AllocationDate = x.AllocationDate,
                AppliedDate = x.AppliedDate,
                BatchSchedule = new IdNameViewModel { Id = x.BatchSchedule.Id, Name = x.BatchSchedule.CourseSchedule.Name },
                Course = new IdNameViewModel { Id = x.Course.Id, Name = x.Course.Name },
                Trainee = new IdNameViewModel { Id = x.Trainee.Id, Name = x.Trainee.FullName },
                Status = new IdNameViewModel { Id = (long)x.Status, Name = x.Status.ToString() }
            };
        }
    }
}
