using Module.Training.Entities;

namespace Module.Training.Data
{
    public class QuestionOptionRequest
    {
        public long? Id { get; set; }
        public string Option { get; set; }
        public bool IsCorrect { get; set; }

        public QuestionOption Map(QuestionOption opt = null)
        {
            var entity = opt ?? new QuestionOption();
            entity.Option = Option;
            entity.IsCorrect = IsCorrect;
            return entity;
        }
    }
}
