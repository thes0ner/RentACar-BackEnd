﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Business.Abstract;
using RentACar.Entities.Concrete;
using RentACar.Entities.DTO;

namespace RentACar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {

        readonly IRentalService _rentalService;

        public RentalsController(IRentalService rentalService)
        {
            _rentalService = rentalService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _rentalService.GetAllRentals();

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

            var result = await _rentalService.GetSingleAsync(id);

            if (!result.Success)
            {
                return NotFound(result.Message);
            }

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] RentalDto rentalDto)
        {
            var result = await _rentalService.AddAsync(rentalDto);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);

        }


        [HttpPut()]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] RentalDto rentalDto)
        {

            if (id <= 0)
            {
                return BadRequest("The provided ID must be a positive number.");
            }

            if (id != rentalDto.Id)
            {
                return BadRequest("Rental ID does not match the ID in the body.");
            }

            var result = await _rentalService.UpdateAsync(rentalDto);

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

            var colorToDelete = await _rentalService.GetSingleAsync(id);

            if (!colorToDelete.Success)
            {
                return NotFound(colorToDelete.Success);
            }

            var result = await _rentalService.DeleteAsync(colorToDelete.Data);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }
    }
}
