using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(ExamQuestion), Schema = SchemaConstants.Training)]
    public class ExamQuestion : BaseEntity
    {
        public long ExamId { get; set; }
        public Exam Exam { get; set; }

        public long QuestionId { get; set; }
        public Question Question { get; set; }

        public int Mark { get; set; }

    }

}
