using Module.Core.Shared;
using Module.Training.Entities;

namespace Module.Training.Data
{
    public class ExpertiseViewModel : IViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public static ExpertiseViewModel Map(Expertise expertise)
        {
            return new ExpertiseViewModel
            {
                Id = expertise.Id,
                Name = expertise.Name
            };
        }
    }
}
