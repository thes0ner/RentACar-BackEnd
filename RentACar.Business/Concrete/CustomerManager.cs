using RentACar.Business.Abstract;
using RentACar.Business.Constants;
using RentACar.Entities.Concrete;
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
    public class CustomerManager : ICustomerService
    {
        private readonly ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public async Task<IResult> AddAsync(Customer customer)
        {
            await _customerDal.AddAsync(customer);

            return new SuccessResult(Messages.CustomerAdded);
        }

        public async Task<IResult> DeleteAsync(Customer customer)
        {
            await _customerDal.DeleteAsync(customer);

            return new SuccessResult(Messages.CustomerDeleted);
        }

        public async Task<IResult> UpdateAsync(Customer customer)
        {
            await _customerDal.UpdateAsync(customer);

            return new SuccessResult(Messages.CustomerUpdated);
        }

        public async Task<IDataResult<Customer>> GetSingleAsync(int id)
        {
            var result = await _customerDal.GetSingleAsync(p => p.Id == id);

            if (result == null)
            {
                return new ErrorDataResult<Customer>(Messages.CustomerNotFound);
            }

            return new SuccessDataResult<Customer>(result, Messages.CustomersListed);
        }

        public IDataResult<IQueryable<Customer>> GetAllCustomers()
        {
            var result = _customerDal.GetAll();

            if (result == null || !result.Any())
            {
                return new ErrorDataResult<IQueryable<Customer>>(Messages.CustomerNotFound);
            }

            return new SuccessDataResult<IQueryable<Customer>>(result, Messages.CustomersListed);
        }

        public IDataResult<IQueryable<Customer>> GetCustomersByName(string firstName)
        {
            var result = _customerDal.GetFiltered(p => p.FirstName == firstName);

            if (result == null || !result.Any())
            {
                return new ErrorDataResult<IQueryable<Customer>>(Messages.CustomerNotFound);
            }

            return new SuccessDataResult<IQueryable<Customer>>(result, Messages.CustomersListed);
        }


        public IDataResult<IQueryable<Customer>> GetCustomersByEmail(string email)
        {
            var result = _customerDal.GetFiltered(p => p.Email == email);

            if (result == null || !result.Any())
            {
                return new ErrorDataResult<IQueryable<Customer>>(Messages.CustomerNotFound);
            }

            return new SuccessDataResult<IQueryable<Customer>>(result, Messages.CustomersListed);
        }
    }
}
