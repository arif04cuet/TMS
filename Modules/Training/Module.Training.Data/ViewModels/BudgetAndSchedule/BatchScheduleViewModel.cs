using Module.Core.Shared;
using Module.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Module.Training.Data
{
    public class BatchScheduleViewModel
    {
        public long Id { get; set; }
        public IdNameViewModel CourseSchedule { get; set; }
        public IdNameViewModel Coordinator { get; set; }
        public IdNameViewModel CoCoordinator { get; set; }
        public int TotalSeat { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public DateTime RegistrationStartDate { get; set; }
        public DateTime RegistrationEndDate { get; set; }
        public string Status { get; set; }
        public IdNameViewModel Category { get; set; }

        public IEnumerable<IdNameViewModel> Modules { get; set; }

        public static Expression<Func<BatchSchedule, BatchScheduleViewModel>> Select()
        {
            var now = DateTime.UtcNow.Date;
            return x => new BatchScheduleViewModel
            {
                Id = x.Id,
                CoCoordinator = x.CoCoordinatorId != null ? new IdNameViewModel { Id = x.CoCoordinator.Id, Name = x.CoCoordinator.FullName } : null,
                Coordinator = x.CoordinatorId != null ? new IdNameViewModel { Id = x.Coordinator.Id, Name = x.Coordinator.FullName } : null,

                CourseSchedule = new IdNameViewModel { Id = x.CourseSchedule.Id, Name = x.CourseSchedule.Name },
                EndDate = x.EndDate,
                RegistrationEndDate = x.RegistrationEndDate,
                RegistrationStartDate = x.RegistrationStartDate,
                StartDate = x.StartDate,
                TotalSeat = x.TotalSeat,
                Status = now < x.RegistrationStartDate.Date ? "UPCOMING" : (now >= x.StartDate.Date && now <= x.EndDate.Date ? "RUNNING" : (now >= x.EndDate.Date ? "FINISHED" : "")),
                Category = new IdNameViewModel { Id = x.CourseSchedule.Course.Category.Id, Name = x.CourseSchedule.Course.Category.Name }
            };
        }

        public static Expression<Func<BatchSchedule, BatchScheduleViewModel>> SelectWithModules()
        {
            var now = DateTime.UtcNow.Date;
            return x => new BatchScheduleViewModel
            {
                Id = x.Id,
                CoCoordinator = x.CoCoordinatorId != null ? new IdNameViewModel { Id = x.CoCoordinator.Id, Name = x.CoCoordinator.FullName } : null,
                Coordinator = x.CoordinatorId != null ? new IdNameViewModel { Id = x.Coordinator.Id, Name = x.Coordinator.FullName } : null,

                CourseSchedule = new IdNameViewModel { Id = x.CourseSchedule.Id, Name = x.CourseSchedule.Name },
                EndDate = x.EndDate,
                RegistrationEndDate = x.RegistrationEndDate,
                RegistrationStartDate = x.RegistrationStartDate,
                StartDate = x.StartDate,
                TotalSeat = x.TotalSeat,
                Status = now < x.RegistrationStartDate.Date ? "UPCOMING" : (now >= x.StartDate.Date && now <= x.EndDate.Date ? "RUNNING" : (now >= x.EndDate.Date ? "FINISHED" : "")),
                Category = new IdNameViewModel { Id = x.CourseSchedule.Course.Category.Id, Name = x.CourseSchedule.Course.Category.Name },
                Modules = x.CourseSchedule.Course.Modules.Select(y => new IdNameViewModel
                {
                    Id = y.CourseModuleId,
                    Name = y.CourseModule.Name
                })
        };
    }
}
}
