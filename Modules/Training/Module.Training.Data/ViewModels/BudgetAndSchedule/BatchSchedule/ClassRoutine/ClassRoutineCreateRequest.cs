using Module.Training.Entities;
using System.Collections.Generic;

namespace Module.Training.Data
{
    public class ClassRoutineCreateRequest
    {
        public long BatchSchedule { get; set; }
        public IEnumerable<ClassRoutineModuleRequest> Modules { get; set; }

        public ClassRoutine Map()
        {
            var classRoutine = new ClassRoutine();
            classRoutine.BatchScheduleId = BatchSchedule;
            return classRoutine;
        }
    }
}
