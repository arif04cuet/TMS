using Module.Core.Shared;
using Module.Training.Entities;

namespace Module.Training.Data
{
    public class GradeViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string GradeName { get; set; }
        public int From { get; set; }
        public int To { get; set; }

        public static GradeViewModel Map(Grade grade)
        {
            return new GradeViewModel
            {
                Id = grade.Id,
                Name = grade.Name,
                GradeName = grade.GradeName,
                From = grade.From,
                To = grade.To
            };
        }
    }
}
