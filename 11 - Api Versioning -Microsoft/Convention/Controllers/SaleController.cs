using Microsoft.AspNetCore.Mvc;

namespace Convention.Controllers
{
    public class SaleController
    {
    }

    // Conventions specified in Startup
    // via HTTP header
    // e.g. /api/sale?api-version=2.0, add api-version header
    [ApiController]
    [Route("api/sale")]
    public class SaleControllerV1 : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Content("Version 1");
    }
    [ApiController]
    [Route("api/sale")]
    public class SaleControllerV2 : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Content("Version 2");
    }
}