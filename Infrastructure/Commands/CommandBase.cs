namespace Infrastructure.Commands
{
    public class CommandBase<TResponse> : ICommand<TResponse>
    {
        public string Source { get; set; }
    }
}
