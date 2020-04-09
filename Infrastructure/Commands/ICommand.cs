using MediatR;

namespace Infrastructure.Commands
{
    public interface ICommand<TResponse> : IRequest<TResponse>
    {

    }
}
