using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Business.Abstract;
using RentACar.Core.Entities.Concrete;

namespace RentACar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCardsController : ControllerBase
    {
        readonly ICreditCardService _creditCardService;

        public CreditCardsController(ICreditCardService creditCardService)
        {
            _creditCardService = creditCardService;
        }


        [HttpGet("getall")]
        public IActionResult GetAllCreditCards()
        {
            var result = _creditCardService.GetAllCreditCards();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }


        [HttpGet("getbyid")]
        public async Task<IActionResult> GetCreditCardById(int id)
        {
            var result = await _creditCardService.GetSingleAsync(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }


        [HttpPost]
        public async Task<IActionResult> AddCreditCard([FromBody] CreditCard creditCard)
        {
            var result = await _creditCardService.AddAsync(creditCard);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }


        [HttpPut]
        public async Task<IActionResult> UpdateCreditCard([FromBody] CreditCard creditCard)
        {
            var result = await _creditCardService.UpdateAsync(creditCard);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }


        [HttpDelete]
        public async Task<IActionResult> DeleteCreditCard([FromQuery] int id)
        {
            var creditCard = await _creditCardService.GetSingleAsync(id);
            var result = await _creditCardService.DeleteAsync(creditCard.Data);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);

        }


    }
}