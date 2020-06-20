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
        public int TotalSeat { get; set; }
        public IEnumerable<IdNameViewModel> EligibleFor { get; set; }
        public IEnumerable<BudgetViewModel> Budgets { get; set; }

        public static Expression<Func<CourseSchedule, CourseScheduleViewModel>> Select()
        {
            return x => new CourseScheduleViewModel
            {
                CoCoordinator = x.CoCoordinatorId != null ? new IdNameViewModel { Id = x.CoCoordinator.Id, Name = x.CoCoordinator.FullName } : null,

                Coordinator = x.CoordinatorId != null ? new IdNameViewModel { Id = x.Coordinator.Id, Name = x.Coordinator.FullName } : null,
                Course = new IdNameViewModel { Id = x.Course.Id, Name = x.Course.Name },
                TotalSeat = x.TotalSeat,
                Id = x.Id,
                Name = x.Name
            };
        }
    }
}
