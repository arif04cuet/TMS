using Module.Core.Shared;
using Module.Training.Entities;

namespace Module.Training.Data
{
    public class EvaluationMethodViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Mark { get; set; }

        public static EvaluationMethodViewModel Map(EvaluationMethod em)
        {
            return new EvaluationMethodViewModel
            {
                Id = em.Id,
                Name = em.Name,
                Mark = em.Mark
            };
        }
    }
}
