namespace Module.Core.Shared
{
    public interface INameViewModel : IViewModel
    {
        long Id { get; set; }
        string Name { get; set; }
    }
}
