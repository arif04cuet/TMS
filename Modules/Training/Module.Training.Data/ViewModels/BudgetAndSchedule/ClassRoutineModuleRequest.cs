using System.Collections.Generic;

namespace Module.Training.Data
{
    public class ClassRoutineModuleRequest
    {
        public long? Id { get; set; }
        public IEnumerable<ModuleRoutineRequest> Routines { get; set; }
    }
}
