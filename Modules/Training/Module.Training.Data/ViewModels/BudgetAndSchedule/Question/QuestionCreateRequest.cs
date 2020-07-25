using Module.Training.Entities;
using System.Collections.Generic;

namespace Module.Training.Data
{
    public class QuestionCreateRequest
    {
        public string Title { get; set; }
        public int Mark { get; set; }
        public int? AnswerLength { get; set; }
        public QuestionType Type { get; set; }
        public IEnumerable<long> Topics { get; set; }
        public IEnumerable<QuestionOptionRequest> Options { get; set; }

        public Question Map(Question question = null)
        {
            var entity = question ?? new Question();
            entity.Title = Title;
            entity.Mark = Mark;
            entity.AnswerLength = AnswerLength;
            entity.Type = Type;
            return entity;
        }
    }
}
