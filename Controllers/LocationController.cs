using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JayRide.Services;

namespace JayRide.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _service;
        public LocationController(ILocationService service)
        {
            _service = service;
        }

        [HttpGet(Name = "GetCityByIP")]
        public async Task<IActionResult> Get(string IP)
        {
            try{
                var location = await _service.GetLocation(IP);

                return Ok(location);  
            }
            catch(Exception ex){
                return NotFound(string.Format("Location IP: {0} no found",IP));
            }
        }
    }
}