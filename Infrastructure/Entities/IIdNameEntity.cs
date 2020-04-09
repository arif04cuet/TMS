namespace Infrastructure.Entities
{
    public interface IIdNameEntity : IEntity
    {
        long Id { get; set; }
        string Name { get; set; }
    }
}
