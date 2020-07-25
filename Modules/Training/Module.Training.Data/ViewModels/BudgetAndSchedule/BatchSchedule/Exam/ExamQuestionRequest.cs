using Module.Core.Shared;

namespace Module.Training.Data
{
    public class ExamQuestionRequest : QuestionCreateRequest
    {
        public long? Id { get; set; }
        public IdNameViewModel Question { get; set; }
    }
}
