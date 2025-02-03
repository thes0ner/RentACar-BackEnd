using RentACar.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Abstract
{
    public interface ICreditCardService
    {
        Task<IEnumerable<CreditCard>> GetCreditCardsAsync();
        Task<CreditCard> GetSingleAsync(int id);
        Task AddAsync(CreditCard creditCard);
        Task UpdateAsync(CreditCard creditCard);
        Task DeleteAsync(CreditCard creditCard);
    }
}
