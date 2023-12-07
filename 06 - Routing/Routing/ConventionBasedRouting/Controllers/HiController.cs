using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConventionBasedRouting.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HiController : ControllerBase
    {
        // GET api/hi/get
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "hi1", "hi2" };
        }

        // GET api/hi/getById/5
     [HttpGet("{id}")]
    public string GetById(int id)
        {
            return "HI - " + id.ToString();
        }

        //POST api/hi/post/
        // application/json - body "Hello-POST"
        [HttpPost]

        public string Post([FromBody] string value)
        {
            return value;
        }

        // PUT api/hi/put/5
        // application/json - body "Hello-PUT"
        [HttpPut]

        public string Put(int id, [FromBody] string value)
        {
            return value;
        }

        // DELETE api/hi/values/5
        [HttpDelete]

        public string Delete(int id)
        {
            return id.ToString();
        }
    }
}