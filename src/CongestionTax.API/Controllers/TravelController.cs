using CongestionTax.Core.Dtos;
using CongestionTax.Core.Service;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CongestionTax.API.Controllers
{
    [ApiController]
    [Route("travels")]
    public class TravelController : ControllerBase
    {
       
        private readonly ITravelService _travelService;

        public TravelController(ITravelService travelService)
        {
            _travelService = travelService;
        }

        // POST: travels
        [HttpPost]
        public async Task<IActionResult> Register(TravelDto travel)
        {
            try
            {
                var result = await _travelService.RegisterTravelAsync(travel);
            return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}