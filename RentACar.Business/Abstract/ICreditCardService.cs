using RentACar.Core.Entities.Concrete;
using RentACar.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Abstract
{
    public interface ICreditCardService
    {
        IDataResult<IQueryable<CreditCard>> GetAllCreditCards();
        IDataResult<IQueryable<CreditCard>> GetCreditCardsByName(string fullName);
        Task<IDataResult<CreditCard>> GetSingleAsync(int id);
        Task<IResult> AddAsync(CreditCard creditCard);
        Task<IResult> UpdateAsync(CreditCard creditCard);
        Task<IResult> DeleteAsync(CreditCard creditCard);
    }
}
