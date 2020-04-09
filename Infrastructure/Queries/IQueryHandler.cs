using MediatR;

namespace Infrastructure.Queries
{
    public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<TQuery, TResponse> where TQuery : IQuery<TResponse>
    {
        //
    }
}
