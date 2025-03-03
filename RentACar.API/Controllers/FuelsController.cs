using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Business.Abstract;
using RentACar.Entities.Concrete;

namespace RentACar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelsController : ControllerBase
    {
        readonly IFuelService _fuelService;

        public FuelsController(IFuelService fuelService)
        {
            _fuelService = fuelService;
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _fuelService.GetAllFuels();

            if (!result.Success || result.Data == null || !result.Data.Any())
            {
                return NotFound(result.Success);
            }

            return Ok(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                return BadRequest("The provided ID must be a positive number.");
            }

            var result = await _fuelService.GetSingleAsync(id);

            if (!result.Success)
            {
                return NotFound(result.Success);
            }

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] Fuel fuel)
        {
            var result = await _fuelService.AddAsync(fuel);

            if (!result.Success)
            {
                return NotFound(result.Message);
            }

            return Ok(result);

        }


        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] Fuel fuel)
        {
            var result = await _fuelService.UpdateAsync(fuel);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync([FromQuery] int id)
        {
            if (id <= 0)
            {
                return BadRequest("The provided ID must be a positive number.");
            }

            var fuelToDelete = await _fuelService.GetSingleAsync(id);

            if (!fuelToDelete.Success)
            {
                return NotFound(fuelToDelete);
            }

            var result = await _fuelService.DeleteAsync(fuelToDelete.Data);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
    }
}
