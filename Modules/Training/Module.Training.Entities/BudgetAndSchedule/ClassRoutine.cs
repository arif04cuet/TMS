using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(ClassRoutine), Schema = SchemaConstants.Training)]
    public class ClassRoutine : BaseEntity
    {

        public ClassRoutine()
        {
            RoutineModules = new HashSet<ClassRoutineModule>();
        }

        public long BatchScheduleId { get; set; }
        public BatchSchedule BatchSchedule { get; set; }

        public ICollection<ClassRoutineModule> RoutineModules { get; set; }
    }
}
