using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Business.Abstract;
using RentACar.Entities.Concrete;

namespace RentACar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoicesController : ControllerBase
    {

        readonly IInvoiceService _invoiceService;

        public InvoicesController(IInvoiceService invoiceService)
        {
            _invoiceService = invoiceService;
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _invoiceService.GetAllInvoices();

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

            var result = await _invoiceService.GetSingleAsync(id);

            if (!result.Success)
            {
                return NotFound(result.Success);
            }

            return Ok(result);
        }


        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] Invoice invoice)
        {
            var result = await _invoiceService.AddAsync(invoice);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }


        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] Invoice invoice)
        {
            var result = await _invoiceService.UpdateAsync(invoice);

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

            var invoiceToDelete = await _invoiceService.GetSingleAsync(id);

            if (!invoiceToDelete.Success)
            {
                return NotFound(invoiceToDelete.Success);
            }

            var result = await _invoiceService.DeleteAsync(invoiceToDelete.Data);

            if (!result.Success)
            {
                return NotFound(result);
            }

            return Ok(result);
        }

    }
}
