using Microsoft.AspNetCore.Mvc;

namespace Subscriptions.Controllers.V1
{
    [ApiController]
    [Route("Api/[Controller]")]
    public sealed class HomesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> GetHomes() =>
            Ok("Thank you Mario, but the princess is in another castle!");
    }
}
