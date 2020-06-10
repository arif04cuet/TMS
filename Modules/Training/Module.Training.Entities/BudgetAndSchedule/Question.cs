using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(Question), Schema = SchemaConstants.Training)]
    public class Question : BaseEntity
    {
        public string Title { get; set; }
        public int Mark { get; set; }
        public QuestionType Type { get; set; }
    }

    public enum QuestionType
    {
        Multiple = 1,
        Written = 2
    }
}
