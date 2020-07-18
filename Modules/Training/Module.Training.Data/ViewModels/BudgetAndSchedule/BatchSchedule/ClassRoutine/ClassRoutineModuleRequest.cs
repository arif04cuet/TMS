using Module.Training.Entities;
using System.Collections.Generic;

namespace Module.Training.Data
{
    public class ClassRoutineModuleRequest
    {
        public long? Id { get; set; }
        public long? Module { get; set; }
        public IEnumerable<ModuleRoutineRequest> Routines { get; set; }

        public ClassRoutineModule Map(ClassRoutineModule classRoutineModule = null)
        {
            var entity = classRoutineModule ?? new ClassRoutineModule();
            entity.CourseModuleId = Module;
            return entity;
        }
    }
}
