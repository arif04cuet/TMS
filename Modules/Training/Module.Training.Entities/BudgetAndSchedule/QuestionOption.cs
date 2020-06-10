using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(QuestionOption), Schema = SchemaConstants.Training)]
    public class QuestionOption : BaseEntity
    {
        public string Option { get; set; }
        public bool IsCorrect { get; set; }

        public long QuestionId { get; set; }
        public Question Question { get; set; }
    }
}
