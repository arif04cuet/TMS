using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(CourseEvaluationMethod), Schema = SchemaConstants.Training)]
    public class CourseEvaluationMethod : BaseEntity
    {
        public long CourseId { get; set; }
        public Course Course { get; set; }

        public long EvaluationMethodId { get; set; }
        public EvaluationMethod EvaluationMethod { get; set; }
    }
}
