using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Business.Abstract;
using RentACar.Entities.Concrete;

namespace RentACar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {

        readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _paymentService.GetAllPayments();

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

            var result = await _paymentService.GetSingleAsync(id);

            if (!result.Success)
            {
                return NotFound(result.Success);
            }

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] Payment payment)
        {
            var result = await _paymentService.AddAsync(payment);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }


        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] Payment payment)
        {
            var result = await _paymentService.UpdateAsync(payment);

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

            var paymentToDelete = await _paymentService.GetSingleAsync(id);

            if (!paymentToDelete.Success)
            {
                return NotFound(paymentToDelete);
            }

            var result = await _paymentService.DeleteAsync(paymentToDelete.Data);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }


    }
}
