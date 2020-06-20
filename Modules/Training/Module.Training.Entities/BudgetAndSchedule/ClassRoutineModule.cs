using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(ClassRoutineModule), Schema = SchemaConstants.Training)]
    public class ClassRoutineModule : BaseEntity
    {

        public ClassRoutineModule()
        {
            ModuleRoutines = new HashSet<ModuleRoutine>();
        }

        public long ClassRoutineId { get; set; }
        public ClassRoutine ClassRoutine { get; set; }

        public ICollection<ModuleRoutine> ModuleRoutines { get; set; }
    }
}
