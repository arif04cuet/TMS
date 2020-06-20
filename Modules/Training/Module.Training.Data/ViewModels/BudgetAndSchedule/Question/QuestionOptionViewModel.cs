using Module.Core.Shared;

namespace Module.Training.Data
{
    public class QuestionOptionViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Option { get; set; }
        public bool IsCorrect { get; set; }
    }
}
