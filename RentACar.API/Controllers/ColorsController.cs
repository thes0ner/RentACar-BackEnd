using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Business.Abstract;
using RentACar.Core.Entities.Concrete;

namespace RentACar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        readonly IColorService _colorService;

        public ColorsController(IColorService colorService)
        {
            _colorService = colorService;
        }


        [HttpGet("getall")]
        public IActionResult GetAllColors()
        {
            var result = _colorService.GetAllColors();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("getbycolorid")]
        public async Task<IActionResult> GetByColorId(int id)
        {
            var result = await _colorService.GetSingleAsync(id);

            if (!result.Success)
            {
                return BadRequest(result.Success);
            }

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> AddColor([FromBody] Color color)
        {
            var result = await _colorService.AddAsync(color);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }


        [HttpPut]
        public async Task<IActionResult> UpdateColor([FromBody] Color color)
        {
            var result = await _colorService.UpdateAsync(color);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColor([FromQuery] int id)
        {
            var color = await _colorService.GetSingleAsync(id);

            var result = await _colorService.DeleteAsync(color.Data);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

    }
}
