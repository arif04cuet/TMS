using Module.Core.Shared;
using Module.Training.Entities;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Module.Training.Data
{
    public class ExamQuestionViewModel
    {
        public long? Id { get; set; }
        public QuestionViewModel Question { get; set; }
        public int Mark { get; set; }

        public static Expression<Func<ExamQuestion, ExamQuestionViewModel>> Select()
        {
            return x => new ExamQuestionViewModel
            {
                Id = x.Id,
                Question = new QuestionViewModel
                {
                    Id = x.Question.Id,
                    Mark = x.Mark,
                    Title = x.Question.Title,
                    Type = new IdNameViewModel { Id = (long)x.Question.Type, Name = x.Question.Type.ToString() },
                    Options = x.Question.Options.Select(y => new QuestionOptionViewModel
                    {
                        Id = y.Id,
                        IsCorrect = y.IsCorrect,
                        Option = y.Option
                    })
                },
                Mark = x.Mark
            };
        }
    }
}
