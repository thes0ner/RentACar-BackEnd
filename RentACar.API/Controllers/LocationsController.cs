using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Business.Abstract;
using RentACar.Entities.Concrete;

namespace RentACar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {

        readonly ILocationService _locationService;

        public LocationsController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var result = _locationService.GetAllLocations();

            if (!result.Success || result.Data == null || !result.Data.Any())
            {
                return NotFound(result.Message);

            }

            return Ok(result);

        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest("The provided ID must be a positive number.");
            }

            var result = await _locationService.GetSingleAsync(id);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);

        }


        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] Location location)
        {

            var result = await _locationService.AddAsync(location);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] Location location)
        {
            var result = await _locationService.UpdateAsync(location);

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

            var locationToDelete = await _locationService.GetSingleAsync(id);

            if (!locationToDelete.Success)
            {
                return NotFound(locationToDelete);
            }

            var result = await _locationService.DeleteAsync(locationToDelete.Data);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);

        }
    }
}
