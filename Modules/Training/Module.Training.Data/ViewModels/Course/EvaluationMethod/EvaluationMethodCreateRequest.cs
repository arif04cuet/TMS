using Module.Training.Entities;

namespace Module.Training.Data
{
    public class EvaluationMethodCreateRequest
    {
        public string Name { get; set; }
        public int Mark { get; set; }

        public EvaluationMethod Map(EvaluationMethod evaluationMethod = null)
        {
            var entity = evaluationMethod ?? new EvaluationMethod();
            entity.Name = Name;
            entity.Mark = Mark;
            return entity;
        }
    }
}
