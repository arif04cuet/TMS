using Module.Core.Shared;
using Module.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Module.Training.Data
{
    public class CourseScheduleViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public IdNameViewModel Course { get; set; }
        public IdNameViewModel Coordinator { get; set; }
        public IdNameViewModel CoCoordinator { get; set; }
        public IdNameViewModel Staff1 { get; set; }
        public IdNameViewModel Staff2 { get; set; }
        public IdNameViewModel Staff3 { get; set; }
        public int TotalSeat { get; set; }
        public IEnumerable<IdNameViewModel> EligibleFor { get; set; }
        public IEnumerable<BudgetViewModel> Budgets { get; set; }

        public static Expression<Func<CourseSchedule, CourseScheduleViewModel>> Select()
        {
            return x => new CourseScheduleViewModel
            {
                CoCoordinator = x.CoCoordinatorId.HasValue ? new IdNameViewModel { Id = x.CoCoordinator.Id, Name = x.CoCoordinator.FullName } : null,
                Coordinator = x.CoordinatorId.HasValue ? new IdNameViewModel { Id = x.Coordinator.Id, Name = x.Coordinator.FullName } : null,

                Staff1 = x.Staff1Id.HasValue ? new IdNameViewModel { Id = x.Staff1.Id, Name = x.Staff1.FullName } : null,
                Staff2 = x.Staff2Id.HasValue ? new IdNameViewModel { Id = x.Staff2.Id, Name = x.Staff2.FullName } : null,
                Staff3 = x.Staff3Id.HasValue ? new IdNameViewModel { Id = x.Staff3.Id, Name = x.Staff3.FullName } : null,

                Course = new IdNameViewModel { Id = x.Course.Id, Name = x.Course.Name },
                TotalSeat = x.TotalSeat,
                Id = x.Id,
                Name = x.Name
            };
        }
    }
}
