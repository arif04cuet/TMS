using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Commands
{
    public interface ICommandBus
    {
        Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default);
    }
}
