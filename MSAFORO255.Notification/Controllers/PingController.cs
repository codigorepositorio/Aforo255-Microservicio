using Microsoft.AspNetCore.Mvc;

namespace MSAFORO255.Notification.Controllers
{
    [Route("")]
    [ApiController]
    public class PingController : ControllerBase
    {
        [HttpGet("ping")]
        public IActionResult Ping()
        {
            return Ok();
        }
    }
}
