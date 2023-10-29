using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JayRide.Services;
using JayRide.Models;
using JayRide.Repositories;

namespace JayRide.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ListingsController : ControllerBase
    {
        private readonly IJayrideService _service;
        private readonly IListingsRepository _repository;
        public ListingsController(IJayrideService service, IListingsRepository repository)
        {
            _service = service;
            _repository = repository;
        }

        [HttpGet(Name = "GetListingByNumberOfPassengers")]
        public async Task<IActionResult> Get(int passengers)
        {
            try{
                if(passengers == 0){
                    throw new Exception("invalid number of passengers");
                }

                var quote = await _service.GetQuote();
                var quoteResponse = _repository.GetListingByNumberOfPassengers(passengers,quote);
                return Ok(quoteResponse);
            }
            catch(Exception ex){
                return BadRequest(ex.Message);
            }          
        }
    }
}