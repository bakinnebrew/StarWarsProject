using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
//using StarWarsProject.Controllers;
using StarWarsProject;
using System.Net;
using static System.Net.WebRequestMethods;

namespace StarWarsProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StarshipController : ControllerBase
    {
        private readonly IStarshipService _starshipService;
     
        public StarshipController(IStarshipService starshipService)
        {
            _starshipService = starshipService;
            //_logger = logger;
        }

        [HttpGet("/starships")]
        public ActionResult GetStarships(string manufacturer)
        {
            var response = _starshipService.GetStarships(manufacturer);

            if (response == null)
            {
                return BadRequest();
            }
            var result = JsonConvert.DeserializeObject<List<Starship>>(response);
            return Ok(result);

        }


    }

}