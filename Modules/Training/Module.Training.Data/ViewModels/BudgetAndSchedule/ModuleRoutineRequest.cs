using Module.Training.Entities;
using System;
using System.Collections.Generic;

namespace Module.Training.Data
{
    public class ModuleRoutineRequest
    {
        public long? Id { get; set; }
        public DateTime TrainingDate { get; set; }
        public IEnumerable<RoutinePeriodRequest> Periods { get; set; }

        public ModuleRoutine Map(ModuleRoutine moduleRoutine = null)
        {
            var entity = moduleRoutine ?? new ModuleRoutine();
            entity.TrainingDate = TrainingDate;
            return entity;
        }
    }
}
