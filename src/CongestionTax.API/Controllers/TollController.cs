using CongestionTax.Core.Dtos;
using CongestionTax.Core.Service;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace CongestionTax.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TollController : ControllerBase
    {
       
        private readonly ITravelService _travelService;

        public TollController(ITravelService travelService)
        {
            _travelService = travelService;
        }

        // POST: travels
        [HttpPost]
        public async Task<IActionResult> Register(TravelDto travel)
        {
            try
            {
                var result = await _travelService.RegisterTollAsync(travel);
            return Ok(result);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}