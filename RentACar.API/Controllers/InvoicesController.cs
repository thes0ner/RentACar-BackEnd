using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Business.Abstract;
using RentACar.Entities.Concrete;
using RentACar.Entities.DTO;

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
        public async Task<IActionResult> AddAsync([FromBody] InvoiceDto invoiceDto)
        {
            var result = await _invoiceService.AddAsync(invoiceDto);

            if (!result.Success)
            {
                return BadRequest(result.Message);
            }

            return Ok(result);

        }


        [HttpPut()]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] InvoiceDto invoiceDto)
        {

            if (id <= 0)
            {
                return BadRequest("The provided ID must be a positive number.");
            }

            if (id != invoiceDto.Id)
            {
                return BadRequest("Invoice ID does not match the ID in the body.");
            }

            var result = await _invoiceService.UpdateAsync(invoiceDto);

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
