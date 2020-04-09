using MediatR;

namespace Infrastructure.Queries
{
    public interface IQueryBehaviour<in TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        //
    }
}
