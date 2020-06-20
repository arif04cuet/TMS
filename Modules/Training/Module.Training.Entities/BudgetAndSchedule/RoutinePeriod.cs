using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(RoutinePeriod), Schema = SchemaConstants.Training)]
    public class RoutinePeriod : BaseEntity
    {
        public long RoutineId { get; set; }
        public ModuleRoutine Routine { get; set; }

        public long? TopicId { get; set; }
        public CourseModuleTopic Topic { get; set; }

        public DateTime TrainingDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public long ResourcePersonId { get; set; }
        public ResourcePerson ResourcePerson { get; set; }
    }
}
