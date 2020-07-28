using Module.Core.Shared;
using System.Collections.Generic;

namespace Module.Training.Data
{

    public class TotalMarkViewModel
    {
        public long? TotalMarkId { get; set; }
        public string ParticipantName { get; set; }
        public long BatchAllocationId { get; set; }
        public ICollection<TotalMarkEvaluationMethodViewModel> EvaluationMethods { get; set; }
        public int TotalMark { get; set; }

    }

    public class TotalMarkEvaluationMethodViewModel : IdNameViewModel
    {
        public int Mark { get; set; }

    }

}
