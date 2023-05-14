using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WeatherEye.Controllers
{
    [Route("api/status")]
    [ApiController]
    public class StatusController : Controller
    {
        [HttpGet]
        public IActionResult getStatus()
        {
            return Ok("OK");
        }
    }
}
