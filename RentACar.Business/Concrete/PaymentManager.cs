using RentACar.Business.Abstract;
using RentACar.Core.Utilities.Results.Abstract;
using RentACar.Core.Utilities.Results.Concrete;
using RentACar.DataAccess.Abstract;
using RentACar.Entities.Concrete;
using RentACar.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        readonly ICreditCardPaymentDal _creditCardPaymentDal;
        readonly IBankPaymentDal _bankPaymentDal;

        public PaymentManager(ICreditCardPaymentDal creditCardPaymentDal, IBankPaymentDal bankPaymentDal)
        {
            _creditCardPaymentDal = creditCardPaymentDal;
            _bankPaymentDal = bankPaymentDal;
        }

        public Task<IResult> AddAsync(Payment payment)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> DeleteAsync(Payment payment)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IQueryable<Payment>> GetAllPayments()
        {
            throw new NotImplementedException();
        }

        public Task<IDataResult<Payment>> GetSingleAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IResult> ProcessPaymentAsync(Payment payment)
        {
            return null;
        }

        public Task<IResult> UpdateAsync(Payment payment)
        {
            throw new NotImplementedException();
        }
    }
}
