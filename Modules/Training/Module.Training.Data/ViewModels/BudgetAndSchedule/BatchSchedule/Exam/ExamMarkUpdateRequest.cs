using System.Collections.Generic;

namespace Module.Training.Data
{
    public class ExamMarkUpdateRequest
    {
        public long Exam { get; set; }
        public IEnumerable<ExamMarkRequest> Marks { get; set; }
    }

    public class ExamMarkRequest
    {
        public long? Id { get; set; }
        public int Mark { get; set; }

        // BatchScheduleAllocation Id
        public long ParticipantId { get; set; }
    }
}
