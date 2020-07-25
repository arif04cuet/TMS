using Module.Core.Shared;
using Module.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Module.Training.Data
{
    public class QuestionViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public int Mark { get; set; }
        public int? AnswerLength { get; set; }
        public IdNameViewModel Type { get; set; }
        public IEnumerable<IdNameViewModel> Topics { get; set; }
        public IEnumerable<QuestionOptionViewModel> Options { get; set; }

        public static Expression<Func<Question, QuestionViewModel>> Select()
        {
            return x => new QuestionViewModel
            {
                Id = x.Id,
                Mark = x.Mark,
                Title = x.Title,
                AnswerLength = x.AnswerLength,
                Type = new IdNameViewModel { Id = (long)x.Type, Name = x.Type.ToString() },
                Options = x.Options.Select(y => new QuestionOptionViewModel
                {
                    Id = y.Id,
                    IsCorrect = y.IsCorrect,
                    Option = y.Option
                })
            };
        }
    }
}
