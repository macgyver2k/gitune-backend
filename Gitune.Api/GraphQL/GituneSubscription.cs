using GraphQL.Types;
using MediatR;

namespace Gitune.Api.GraphQL
{
    public class GituneSubscription : ObjectGraphType
    {
        public GituneSubscription(IMediator mediator, IEventSource eventSource)
        {
            
        }
    }
}