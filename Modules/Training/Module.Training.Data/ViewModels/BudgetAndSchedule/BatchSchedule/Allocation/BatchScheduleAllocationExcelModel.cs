using Module.Training.Entities;
using System;
using System.Linq.Expressions;

namespace Module.Training.Data
{
    public class BatchScheduleAllocationExcelModel
    {
        public string Schedule { get; set; }
        public string Course { get; set; }
        public string Trainee { get; set; }
        public string AppliedDate { get; set; }
        public string AllocationDate { get; set; }

        public static Expression<Func<BatchScheduleAllocation, BatchScheduleAllocationExcelModel>> Select()
        {
            return x => new BatchScheduleAllocationExcelModel
            {
                AllocationDate = x.AllocationDate == null ? "" : x.AllocationDate.ToString(),
                AppliedDate = x.AppliedDate.ToString(),
                Schedule = x.BatchSchedule.CourseSchedule.Name,
                Course = x.Course.Name,
                Trainee = x.Trainee.FullName
            };
        }
    }
}
