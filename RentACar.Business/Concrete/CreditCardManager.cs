using RentACar.Business.Abstract;
using RentACar.Business.Constants;
using RentACar.Core.Entities.Concrete;
using RentACar.Core.Utilities.Results.Abstract;
using RentACar.Core.Utilities.Results.Concrete;
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

        public async Task<IResult> AddAsync(CreditCard creditCard)
        {
            await _creditCardDal.AddAsync(creditCard);

            return new SuccessResult(Messages.CreditCardAdded);
        }

        public async Task<IResult> DeleteAsync(CreditCard creditCard)
        {
            await _creditCardDal.DeleteAsync(creditCard);

            return new SuccessResult(Messages.CreditCardDeleted);

        }

        public async Task<IResult> UpdateAsync(CreditCard creditCard)
        {
            await _creditCardDal.UpdateAsync(creditCard);

            return new SuccessResult(Messages.CreditCardUpdated);
        }

        public async Task<IDataResult<IEnumerable<CreditCard>>> GetCreditCardsAsync()
        {
            var result = await _creditCardDal.GetAllAsync();

            if (result == null)
            {
                return new ErrorDataResult<IEnumerable<CreditCard>>(Messages.CreditCardNotFound);
            }

            return new SuccessDataResult<IEnumerable<CreditCard>>(result, Messages.CreditCardsListed);
        }

        public async Task<IDataResult<CreditCard>> GetSingleAsync(int id)
        {
            var result = await _creditCardDal.GetSingleAsync(p => p.Id == id);

            if (result == null)
            {
                return new ErrorDataResult<CreditCard>(Messages.CreditCardNotFound);
            }

            return new SuccessDataResult<CreditCard>(result, Messages.CreditCardsListed);
        }


    }
}
