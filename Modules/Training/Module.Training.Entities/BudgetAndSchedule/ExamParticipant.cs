using Infrastructure.Entities;
using Module.Core.Entities;
using Module.Core.Entities.Constants;
using System.ComponentModel.DataAnnotations.Schema;

namespace Module.Training.Entities
{
    [Table(nameof(ExamParticipant), Schema = SchemaConstants.Training)]
    public class ExamParticipant : BaseEntity
    {
        public long ExamId { get; set; }
        public Exam Exam { get; set; }

        public long ParticipantId { get; set; }
        public User Participant { get; set; }

    }

}
