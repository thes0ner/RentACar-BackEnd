using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Business.Abstract;
using RentACar.Entities.Concrete;

namespace RentACar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        readonly ICustomerService _customerService;


        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _customerService.GetAllCustomers();

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

            var result = await _customerService.GetSingleAsync(id);

            if (!result.Success)
            {
                return NotFound(result.Message);
            }

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] Customer customer)
        {

            var result = await _customerService.AddAsync(customer);

            if (!result.Success)
            {
                return NotFound(result.Message);
            }

            return Ok(result);

        }


        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] Customer customer)
        {
            var result = await _customerService.UpdateAsync(customer);

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

            var customerToDelete = await _customerService.GetSingleAsync(id);

            if (!customerToDelete.Success)
            {
                return NotFound(customerToDelete);
            }

            var result = await _customerService.DeleteAsync(customerToDelete.Data);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

    }
}
