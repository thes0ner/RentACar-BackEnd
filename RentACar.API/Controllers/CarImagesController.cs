using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Business.Abstract;
using RentACar.Entities.Concrete;

namespace RentACar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarImagesController : ControllerBase
    {

        readonly ICarImageService _carImageService;

        public CarImagesController(ICarImageService carImageService)
        {
            _carImageService = carImageService;
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _carImageService.GetAllCarImages();

            if (!result.Success || result.Data == null || !result.Data.Any())
            {
                return NotFound(result.Message);
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

            var result = await _carImageService.GetSingleAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Success);
            }

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CarImage carImage)
        {
            var result = await _carImageService.AddAsync(carImage);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }


        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] CarImage carImage)
        {
            var result = await _carImageService.UpdateAsync(carImage);

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

            var carImageToDelete = await _carImageService.GetSingleAsync(id);

            if (!carImageToDelete.Success)
            {
                return BadRequest(carImageToDelete);
            }

            var result = await _carImageService.DeleteAsync(carImageToDelete.Data);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
    }
}
