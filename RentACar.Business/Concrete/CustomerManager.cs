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
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public async Task AddAsync(Customer customer)
        {
            await _customerDal.AddAsync(customer);
        }

        public async Task DeleteAsync(Customer customer)
        {
            await _customerDal.DeleteAsync(customer);
        }

        public async Task UpdateAsync(Customer customer)
        {
            await _customerDal.UpdateAsync(customer);
        }

        public async Task<IEnumerable<Customer>> GetCustomersAsync()
        {
            return await _customerDal.GetAllAsync();
        }

        public async Task<Customer> GetSingleAsync(int id)
        {
            return await _customerDal.GetSingleAsync(c => c.Id == id);
        }


    }
}
