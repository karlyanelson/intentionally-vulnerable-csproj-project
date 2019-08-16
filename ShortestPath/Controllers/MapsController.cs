using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShortestPath.Facades;
using ShortestPath.Models;

namespace ShortestPath.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MapsController : ControllerBase
    {
        private IMapFacade _mapFacade;

        public MapsController(IMapFacade mapFacade)
        {
            _mapFacade = mapFacade;
        }

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

        // PUT maps/5
        [HttpPut("{mapId}")]
        public void Put(string mapId, [FromBody] ViewMap viewMap)
        {
            _mapFacade.SaveMap(mapId, viewMap);
        }

    }
}
