using Module.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Module.Training.Data
{
    public class ClassRoutineViewModel
    {
        public long Id { get; set; }
        public IEnumerable<ClassRoutineModuleRequest> Modules { get; set; }

        public static Expression<Func<ClassRoutine, ClassRoutineViewModel>> Select()
        {
            return a => new ClassRoutineViewModel
            {
                Id = a.Id,
                Modules = a.RoutineModules.Select(b => new ClassRoutineModuleRequest
                {
                    Id = b.Id,
                    Module = b.CourseModuleId,
                    Routines = b.ModuleRoutines.Select(c => new ModuleRoutineRequest
                    {
                        Id = c.Id,
                        TrainingDate = c.TrainingDate,
                        Periods = c.Periods.Select(d => new RoutinePeriodRequest
                        {
                            Id = d.Id,
                            EndDate = d.EndDate,
                            ResourcePerson = d.ResourcePersonId,
                            StartDate = d.StartDate,
                            Topic = d.TopicId
                        })
                    })
                })
            };
        }
    }
}
