using Microsoft.AspNetCore.Mvc;

namespace CyberpunkBackend.Controllers
{
    [ApiController]
    [Route("/liveness")]
    public class LivenessController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }
    }
}
