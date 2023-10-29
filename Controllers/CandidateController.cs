using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JayRide.Models;

namespace JayRide.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidateController : ControllerBase
    {
        [HttpGet(Name = "GetCandidate")]
        public IActionResult Get()
        {
            return Ok(new Candidate{
                Name = "Jaime Andres Fandino Herrera",
                Phone = "0478199123"
            });            
        }
    }
}