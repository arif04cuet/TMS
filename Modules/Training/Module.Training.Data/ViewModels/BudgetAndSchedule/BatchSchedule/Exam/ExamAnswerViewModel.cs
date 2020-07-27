using Module.Core.Shared;
using System.Collections.Generic;

namespace Module.Training.Data
{
    public class ExamAnswerViewModel : IdNameViewModel
    {
        public IEnumerable<ExamAnswerQuestionViewModel> Questions { get; set; }
    }

    public class ExamAnswerQuestionViewModel : IdNameViewModel {
        public IEnumerable<IdNameViewModel> Options { get; set; }
        public string WrittenAnswer { get; set; }
        public long? McqAnswer { get; set; }
    }
}
