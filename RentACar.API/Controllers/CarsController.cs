using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using RentACar.Business.Abstract;
using RentACar.Entities.Concrete;
using RentACar.Entities.DTO;

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
                return NotFound(result.Message);
            }

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CarDto carDto)
        {
            var result = await _carService.AddAsync(carDto);

            if (!result.Success)
            {
                return NotFound(result.Message);
            }

            return Ok(result);

        }


        [HttpPut()]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] CarDto carDto)
        {

            if (id <= 0)
            {
                return BadRequest("The provided ID must be a positive number.");
            }

            if (id != carDto.Id)
            {
                return BadRequest("Car ID does not match the ID in the body.");
            }

            var result = await _carService.UpdateAsync(carDto);

            if (!result.Success)
                return BadRequest(result.Message);


            return Ok(result.Message);
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


        //[HttpPatch("updatebyid")]
        //public async Task<IActionResult> UpdateAsync(int id, [FromBody] JsonPatchDocument<CarDto> patchDoc)
        //{
        //    if (id <= 0)
        //    {
        //        return BadRequest("The provided ID must be a positive number.");
        //    }

        //    if (patchDoc == null)
        //    {
        //        return BadRequest("Invalid patch data.");
        //    }

        //    var existingCar = await _carService.GetSingleAsync(id);
        //    if (existingCar == null || !existingCar.Success)
        //    {
        //        return NotFound("Car not found.");
        //    }

        //    var carToUpdate = existingCar.Data;

        //    patchDoc.ApplyTo(carToUpdate);


        //    // here has problem can not convert car to cardto
        //    var result = await _carService.UpdateAsync(carToUpdate);

        //    return Ok(result);
        //}


    }
}
