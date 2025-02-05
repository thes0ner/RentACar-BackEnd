using RentACar.Core.Entities.Concrete;
using RentACar.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Abstract
{
    public interface ICustomerService
    {
        Task<IDataResult<IEnumerable<Customer>>> GetCustomersAsync();
        Task<IDataResult<Customer>> GetSingleAsync(int id);
        Task<IResult> AddAsync(Customer customer);
        Task<IResult> UpdateAsync(Customer customer);
        Task<IResult> DeleteAsync(Customer customer);
    }
}
