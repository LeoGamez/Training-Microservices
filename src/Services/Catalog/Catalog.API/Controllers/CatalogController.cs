using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        [HttpGet("HealthCheck")]
        public IActionResult HealtchCheck()
        {
            return Ok("Healthy");
        }
    }
}
