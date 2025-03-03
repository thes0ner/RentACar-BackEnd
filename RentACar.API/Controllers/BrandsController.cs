using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Business.Abstract;
using RentACar.Business.Constants;
using RentACar.Entities.Concrete;

namespace RentACar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        readonly IBrandService _brandService;

        public BrandsController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {

            var result = _brandService.GetAllBrands();

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

            var result = await _brandService.GetSingleAsync(id);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);

        }


        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] Brand brand)
        {

            var result = await _brandService.AddAsync(brand);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] Brand brand)
        {

            var result = await _brandService.UpdateAsync(brand);

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

            var brandToDelete = await _brandService.GetSingleAsync(id);

            if (!brandToDelete.Success)
            {
                return NotFound(brandToDelete);
            }

            var result = await _brandService.DeleteAsync(brandToDelete.Data);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);

        }


    }
}
