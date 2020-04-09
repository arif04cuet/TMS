using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Queries
{
    public class QueryBus : IQueryBus
    {

        private readonly IMediator _mediator;

        public QueryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task<TResponse> SendAsync<TResponse>(IQuery<TResponse> query, CancellationToken cancellationToken = default)
        {
            return _mediator.Send(query, cancellationToken);
        }

    }
}
