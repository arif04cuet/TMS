using Module.Core.Shared;
using System.Collections.Generic;

namespace Module.Training.Data
{

    public class TotalMarkViewModel
    {
        public long? Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<TotalMarkEvaluationMethodViewModel> EvaluationMethods { get; set; }
        public int Mark { get; set; }

    }

    public class TotalMarkEvaluationMethodViewModel : IdNameViewModel
    {
        public int Mark { get; set; }

    }

}
