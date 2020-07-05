using Module.Training.Entities;
using System;
using System.Linq.Expressions;

namespace Module.Training.Data
{
    public class ExamParticipantViewRequest
    {
        public long? Id { get; set; }
        public int Mark { get; set; }
        public string Name { get; set; }
        public long ParticipantId { get; set; }
        public long ExamId { get; set; }

        public static Expression<Func<ExamParticipant, ExamParticipantViewRequest>> Select()
        {
            return x => new ExamParticipantViewRequest
            {
                Id = x.Id
            };
        }
    }
}
