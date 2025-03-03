using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Business.Abstract;
using RentACar.Entities.Concrete;

namespace RentACar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        readonly ICarService _carService;

        public CarsController(ICarService carService)
        {
            _carService = carService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carService.GetAllCars();

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

            var result = await _carService.GetSingleAsync(id);

            if (!result.Success)
            {
                return NotFound(result.Success);
            }

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] Car car)
        {
            var result = await _carService.AddAsync(car);

            if (!result.Success)
            {
                return NotFound(result.Message);
            }

            return Ok(result);

        }


        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] Car car)
        {
            var result = await _carService.UpdateAsync(car);

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

            var carToDelete = await _carService.GetSingleAsync(id);

            if (!carToDelete.Success)
            {
                return NotFound(carToDelete);
            }

            var result = await _carService.DeleteAsync(carToDelete.Data);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

    }
}
