namespace Infrastructure.Entities
{
    [IgnoredEntity]
    public class IdNameEntity : BaseEntity, IIdNameEntity
    {
        public IdNameEntity()
        {

        }

        public IdNameEntity(long id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; set; }
    }
}
