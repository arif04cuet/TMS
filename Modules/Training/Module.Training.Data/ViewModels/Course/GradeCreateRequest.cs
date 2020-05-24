using Module.Training.Entities;

namespace Module.Training.Data
{
    public class GradeCreateRequest
    {
        public string Name { get; set; }
        public int From { get; set; }
        public int To { get; set; }

        public Grade Map(Grade grade = null)
        {
            var entity = grade ?? new Grade();
            entity.Name = Name;
            entity.From = From;
            entity.To = To;
            return entity;
        }
    }
}
