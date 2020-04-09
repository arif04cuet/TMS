using MediatR;

namespace Infrastructure.Commands
{
    public interface ICommandHandler<TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
        where TCommand : ICommand<TResponse>
    {
        //
    }
}
