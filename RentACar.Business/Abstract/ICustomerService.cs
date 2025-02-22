using RentACar.Entities.Concrete;
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
        IDataResult<IQueryable<Customer>> GetAllCustomers();
        IDataResult<IQueryable<Customer>> GetCustomersByName(string firstName);
        IDataResult<IQueryable<Customer>> GetCustomersByEmail(string email);
        Task<IDataResult<Customer>> GetSingleAsync(int id);
        Task<IResult> AddAsync(Customer customer);
        Task<IResult> UpdateAsync(Customer customer);
        Task<IResult> DeleteAsync(Customer customer);
    }
}
