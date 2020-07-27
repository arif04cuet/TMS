using System.Collections.Generic;

namespace Module.Training.Data
{
    public class SubmitExamAnswerRequest
    {
        public long ExamId { get; set; }
        public IEnumerable<SubmitAnswerRequest> Answers { get; set; }
    }
}
