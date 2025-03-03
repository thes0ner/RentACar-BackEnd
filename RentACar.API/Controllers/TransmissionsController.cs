using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Business.Abstract;
using RentACar.Entities.Concrete;

namespace RentACar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransmissionsController : ControllerBase
    {
        readonly ITransmissionService _transmissionService;

        public TransmissionsController(ITransmissionService transmissionService)
        {
            _transmissionService = transmissionService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _transmissionService.GetAllTransmissions();

            if (!result.Success || result.Data == null || !result.Data.Any())
            {
                return NotFound(result.Message);

            }

            return Ok(result);
        }

        [HttpGet("getbyid")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            if(id <= 0)
            {
                return BadRequest("The provided ID must be a positive number.");
            }

            var result = await _transmissionService.GetSingleAsync(id);

            if (!result.Success)
            {
                return NotFound(result.Success);
            }

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] Transmission transmission)
        {
            var result = await _transmissionService.AddAsync(transmission);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }


        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] Transmission transmission)
        {
            var result = await _transmissionService.UpdateAsync(transmission);

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

            var transmissionToDelete = await _transmissionService.GetSingleAsync(id);

            if (!transmissionToDelete.Success)
            {
                return NotFound(transmissionToDelete);
            }

            var result = await _transmissionService.DeleteAsync(transmissionToDelete.Data);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
    }
}
