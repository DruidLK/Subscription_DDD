using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Subscriptions.Contracts.Commands;

namespace Subscriptions.Controllers.V1
{
    [ApiController]
    [Route(template: "Api/[Controller]")]
    public sealed class SubscribtionsController : ControllerBase
    {
        private readonly IMediator mediator;

        public SubscribtionsController(IMediator mediator) =>
            this.mediator = mediator;

        [HttpPost]
        public async ValueTask<IActionResult> Subscribe(SubscribeRequest subscribeRequest)
        {
            await this.mediator.Send(subscribeRequest);

            return Ok();
        }
    }
}
