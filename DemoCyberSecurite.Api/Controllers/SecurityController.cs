using DemoCyberSecurite.Api.Properties;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoCyberSecurite.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SecurityController : ControllerBase
    {
        [HttpGet("publickey")]
        public IActionResult Get()
        {
            return Ok(new { PublicKey = Resources.PublicKey });
        }
    }
}
