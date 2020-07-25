using Module.Training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Module.Training.Data
{
    public class ExamPaperPdfModel
    {
        public DateTime Date { get; set; }
        public string CourseName { get; set; }
        public bool IsWritten { get; set; }
        public bool IsMcq { get; set; }
        public IEnumerable<QuestionPdfModel> Questions { get; set; }

        public static Expression<Func<Exam, ExamPaperPdfModel>> Select()
        {
            return x => new ExamPaperPdfModel
            {
                CourseName = x.BatchSchedule.CourseSchedule.Name,
                Date = DateTime.UtcNow,
                IsMcq = x.QuestionType.HasValue && x.QuestionType == ExamQuestionType.MCQ,
                IsWritten = x.QuestionType.HasValue && x.QuestionType == ExamQuestionType.Written,
            };
        }
    }

    public class QuestionPdfModel
    {
        public string Title { get; set; }
        public IEnumerable<QuestionOptionPdfModel> Options { get; set; }

        public static Expression<Func<ExamQuestion, QuestionPdfModel>> Select()
        {
            return x => new QuestionPdfModel
            {
                Title = x.Question.Title,
                Options = x.Question.Type == QuestionType.Multiple ? x.Question.Options.Select(y => new QuestionOptionPdfModel
                {
                    Title = y.Option
                }) : null
            };
        }
    }

    public class QuestionOptionPdfModel
    {
        public string Title { get; set; }
    }

}
