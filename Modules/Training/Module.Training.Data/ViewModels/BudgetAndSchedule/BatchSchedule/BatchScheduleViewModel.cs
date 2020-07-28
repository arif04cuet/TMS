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
        public string Name { get; set; }
        public long Id { get; set; }
        public IdNameViewModel CourseSchedule { get; set; }
        public IdNameViewModel Coordinator { get; set; }
        public IdNameViewModel CoCoordinator { get; set; }

        public IdNameViewModel Staff1 { get; set; }
        public IdNameViewModel Staff2 { get; set; }
        public IdNameViewModel Staff3 { get; set; }

        public int TotalSeat { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public DateTime RegistrationStartDate { get; set; }
        public DateTime RegistrationEndDate { get; set; }
        public string Status { get; set; }
        public IdNameViewModel Category { get; set; }
        public IdNameViewModel Course { get; set; }
        public IEnumerable<IdNameViewModel> Modules { get; set; }

        public static Expression<Func<BatchSchedule, BatchScheduleViewModel>> Select()
        {
            var now = DateTime.UtcNow.Date;
            return x => new BatchScheduleViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CoCoordinator = x.CoCoordinatorId.HasValue ? new IdNameViewModel { Id = x.CoCoordinator.Id, Name = x.CoCoordinator.FullName } : null,
                Coordinator = x.CoordinatorId.HasValue ? new IdNameViewModel { Id = x.Coordinator.Id, Name = x.Coordinator.FullName } : null,

                Staff1 = x.Staff1Id.HasValue ? new IdNameViewModel { Id = x.Staff1.Id, Name = x.Staff1.FullName } : null,
                Staff2 = x.Staff2Id.HasValue ? new IdNameViewModel { Id = x.Staff2.Id, Name = x.Staff2.FullName } : null,
                Staff3 = x.Staff3Id.HasValue ? new IdNameViewModel { Id = x.Staff3.Id, Name = x.Staff3.FullName } : null,

                CourseSchedule = new IdNameViewModel { Id = x.CourseSchedule.Id, Name = x.CourseSchedule.Name },
                EndDate = x.EndDate,
                RegistrationEndDate = x.RegistrationEndDate,
                RegistrationStartDate = x.RegistrationStartDate,
                StartDate = x.StartDate,
                TotalSeat = x.TotalSeat,
                Status = now < x.RegistrationStartDate.Date ? "UPCOMING" : (now >= x.StartDate.Date && now <= x.EndDate.Date ? "RUNNING" : (now >= x.EndDate.Date ? "FINISHED" : "")),
                Category = new IdNameViewModel { Id = x.CourseSchedule.Course.Category.Id, Name = x.CourseSchedule.Course.Category.Name },
                Course = new IdNameViewModel { Id = x.CourseSchedule.Course.Id, Name = x.CourseSchedule.Course.Name }
            };
        }

        public static Expression<Func<BatchSchedule, BatchScheduleViewModel>> SelectWithModules()
        {
            var now = DateTime.UtcNow.Date;
            return x => new BatchScheduleViewModel
            {
                Id = x.Id,
                Name = x.Name,
                CoCoordinator = x.CoCoordinatorId != null ? new IdNameViewModel { Id = x.CoCoordinator.Id, Name = x.CoCoordinator.FullName } : null,
                Coordinator = x.CoordinatorId != null ? new IdNameViewModel { Id = x.Coordinator.Id, Name = x.Coordinator.FullName } : null,

                Staff1 = x.Staff1Id.HasValue ? new IdNameViewModel { Id = x.Staff1.Id, Name = x.Staff1.FullName } : null,
                Staff2 = x.Staff2Id.HasValue ? new IdNameViewModel { Id = x.Staff2.Id, Name = x.Staff2.FullName } : null,
                Staff3 = x.Staff3Id.HasValue ? new IdNameViewModel { Id = x.Staff3.Id, Name = x.Staff3.FullName } : null,

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
