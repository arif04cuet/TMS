using Infrastructure.Entities;

namespace Module.Core.Entities
{
    public class District : IEntity
    {
        public long Id { get; set; }
        public string Name { get; set; }
        
        public District()
        {

        }

        public District(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
