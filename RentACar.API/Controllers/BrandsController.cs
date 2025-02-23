using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Business.Abstract;
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

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);

        }

        [HttpGet("getbybrandid")]
        public async Task<IActionResult> GetByBrandId(int id)
        {
            var result = await _brandService.GetSingleAsync(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }


        [HttpPost]
        public async Task<IActionResult> AddBrand([FromBody] Brand brand)
        {

            var result = await _brandService.AddAsync(brand);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateBrand([FromBody] Brand brand)
        {
            var result = await _brandService.UpdateAsync(brand);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBrand([FromQuery] int id)
        {
            var brand = await _brandService.GetSingleAsync(id);

            var result = await _brandService.DeleteAsync(brand.Data);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }


    }
}
