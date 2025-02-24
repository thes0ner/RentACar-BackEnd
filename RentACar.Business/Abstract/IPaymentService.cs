using RentACar.Core.Utilities.Results.Abstract;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Abstract
{
    public interface IPaymentService
    {
        //Task<IDataResult<Payment>> GetSingleAsync(int id);
        Task<IDataResult<Payment>> GetSingleCreditCardAsync(int id);
        Task<IDataResult<Payment>> GetSingleBankTransferAsync(int id);
        IDataResult<IQueryable<Payment>> GetAllPayments();
        Task<IResult> AddAsync(Payment payment);
        Task<IResult> UpdateAsync(Payment payment);
        Task<IResult> DeleteAsync(Payment payment);
       
        
        //Task<IResult> ProcessPaymentAsync(Payment payment);
        //Task<IDataResult<Payment>> ProcessCreditCardPaymentAsync(CreditCardPayment payment);
        //Task<IDataResult<Payment>> ProcessBankTransferPaymentAsync(BankTransferPayment payment);
        //Task<IDataResult<Payment>> ProcessCashPaymentAsync(Payment payment);
    }
}
