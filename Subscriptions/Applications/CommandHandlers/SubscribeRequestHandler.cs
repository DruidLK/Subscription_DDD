using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Subscriptions.Contracts.Commands;

namespace Subscriptions.Applications.CommandHandlers
{
    public class SubscribeRequestHandler : IRequestHandler<SubscribeRequest>
    {
        public Task<Unit> Handle(SubscribeRequest request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
