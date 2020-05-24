using Module.Core.Shared;
using Module.Training.Entities;

namespace Module.Training.Data
{
    public class GradeViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int From { get; set; }
        public int To { get; set; }

        public static GradeViewModel Map(Grade grade)
        {
            return new GradeViewModel
            {
                Id = grade.Id,
                Name = grade.Name,
                From = grade.From,
                To = grade.To
            };
        }
    }
}
