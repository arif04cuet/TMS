using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(ModuleRoutine), Schema = SchemaConstants.Training)]
    public class ModuleRoutine : BaseEntity
    {

        public ModuleRoutine()
        {
            Periods = new HashSet<RoutinePeriod>();
        }

        public long ModuleId { get; set; }
        public ClassRoutineModule Module { get; set; }
        public DateTime TrainingDate { get; set; }

        public ICollection<RoutinePeriod> Periods { get; set; }
    }
}
