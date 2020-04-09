using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Commands
{
    public class CommandBus : ICommandBus
    {

        private readonly IMediator _mediator;

        public CommandBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> command, CancellationToken cancellationToken = default)
        {
            return _mediator.Send(command, cancellationToken);

        }
    }
}
