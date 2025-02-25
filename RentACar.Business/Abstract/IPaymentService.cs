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
        IDataResult<IQueryable<Payment>> GetAllPayments();
        Task<IDataResult<Payment>> GetSingleAsync(int id);
        Task<IResult> AddAsync(Payment payment);
        Task<IResult> UpdateAsync(Payment payment);
        Task<IResult> DeleteAsync(Payment payment);


        //Task<IResult> ProcessPaymentAsync(Payment payment);
        //Task<IResult> CancelPaymentAsync(int paymentId);
        //Task<IResult> RefundPaymentAsync(int paymentId, decimal refundAmount);
        //Task<IResult> UpdatePaymentStatusAsync(int paymentId, string status);
        //Task<IResult> ApprovePaymentAsync(int paymentId);
        //Task<IDataResult<IEnumerable<Payment>>> GetPaymentHistoryAsync(string userId);
    }
}
