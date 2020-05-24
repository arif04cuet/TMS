using Module.Training.Entities;

namespace Module.Training.Data
{
    public class ExpertiseCreateRequest
    {
        public string Name { get; set; }

        public Expertise Map(Expertise expertise = null)
        {
            var entity = expertise ?? new Expertise();
            entity.Name = Name;
            return entity;
        }
    }
}
