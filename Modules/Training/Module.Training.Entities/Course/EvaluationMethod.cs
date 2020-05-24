using Infrastructure.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(EvaluationMethod), Schema = SchemaConstants.Training)]
    public class EvaluationMethod : IdNameEntity
    {
        public int Mark { get; set; }
    }
}
