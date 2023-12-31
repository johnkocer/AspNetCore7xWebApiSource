﻿using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Basic.Controllers
{
    // via query string
    // e.g. api/student?api-version=2.0
    [ApiVersion(1.0)]
    [ApiController]

    [Route("api/student")]
    public class StudentControllerV1 : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Content("Version 1.0");
    }

    [ApiVersion(2.0)]
    [ApiController]
    [Route("api/student")]
    public class StudentControllerV2 : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Content("Version 2.0");
    }

}
