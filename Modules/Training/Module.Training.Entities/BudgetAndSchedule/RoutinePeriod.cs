﻿using Infrastructure.Entities;
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
        public Topic Topic { get; set; }

        public DateTime TrainingDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public long ResourcePersonId { get; set; }
        public ResourcePerson ResourcePerson { get; set; }

        public bool SessionCompleted { get; set; }
    }
}
