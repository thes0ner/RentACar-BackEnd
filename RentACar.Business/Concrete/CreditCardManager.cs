using RentACar.Business.Abstract;
using RentACar.Core.Entities.Concrete;
using RentACar.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Concrete
{
    public class CreditCardManager : ICreditCardService
    {
        private readonly ICreditCardDal _creditCardDal;

        public CreditCardManager(ICreditCardDal creditCardDal)
        {
            _creditCardDal = creditCardDal;
        }

        public async Task AddAsync(CreditCard creditCard)
        {
            await _creditCardDal.AddAsync(creditCard);
        }

        public async Task DeleteAsync(CreditCard creditCard)
        {
            await _creditCardDal.DeleteAsync(creditCard);
        }

        public async Task UpdateAsync(CreditCard creditCard)
        {
            await _creditCardDal.UpdateAsync(creditCard);
        }

        public async Task<IEnumerable<CreditCard>> GetCreditCardsAsync()
        {
            return await _creditCardDal.GetAllAsync();
        }

        public async Task<CreditCard> GetSingleAsync(int id)
        {
            return await _creditCardDal.GetSingleAsync(c => c.Id == id);
        }
    }
}
