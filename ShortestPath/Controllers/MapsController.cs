using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ShortestPath.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MapsController : ControllerBase
    {
        // GET maps
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET maps/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST maps
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT maps/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE maps/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
