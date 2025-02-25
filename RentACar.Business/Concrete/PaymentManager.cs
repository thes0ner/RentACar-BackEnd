using RentACar.Business.Abstract;
using RentACar.Business.Constants;
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
        readonly ICreditCardDal _creditCardDal;
        readonly IBankTransferDal _bankTransferDal;

        public PaymentManager(ICreditCardDal creditCardDal, IBankTransferDal bankTransferDal)
        {
            _creditCardDal = creditCardDal;
            _bankTransferDal = bankTransferDal;
        }

        public async Task<IResult> AddAsync(Payment payment)
        {
            if (payment is CreditCard creditCard)
            {
                await _creditCardDal.AddAsync(creditCard);
                return new SuccessResult(Messages.CreditCardAdded);
            }
            else if (payment is BankTransfer bankTransfer)
            {
                await _bankTransferDal.AddAsync(bankTransfer);
                return new SuccessResult(Messages.BankTransferAdded);
            }

            return new ErrorResult(Messages.PaymentTypeInvalid);

        }

        public async Task<IResult> UpdateAsync(Payment payment)
        {
            if (payment is CreditCard creditCard)
            {
                await _creditCardDal.UpdateAsync(creditCard);
                return new SuccessResult(Messages.CreditCardUpdated);
            }
            else if (payment is BankTransfer bankTransfer)
            {
                await _bankTransferDal.UpdateAsync(bankTransfer);
                return new SuccessResult(Messages.BankTransferUpdated);
            }

            return new ErrorResult(Messages.PaymentTypeInvalid);

        }

        public async Task<IResult> DeleteAsync(Payment payment)
        {
            if (payment is CreditCard creditCard)
            {
                await _creditCardDal.DeleteAsync(creditCard);
                return new SuccessResult(Messages.CreditCardDeleted);
            }
            else if (payment is BankTransfer bankTransfer)
            {
                await _bankTransferDal.DeleteAsync(bankTransfer);
                return new SuccessResult(Messages.BankTransferDeleted);
            }

            return new ErrorResult(Messages.PaymentTypeInvalid);
        }

        public IDataResult<IQueryable<Payment>> GetAllPayments()
        {
            var bankTransfers = _bankTransferDal.GetAll();
            var creditCards = _creditCardDal.GetAll();

            // Concatenate bank transfers and credit cards, then return as queryable
            var payments = bankTransfers.Cast<Payment>().Concat(creditCards.Cast<Payment>()).AsQueryable();

            return new SuccessDataResult<IQueryable<Payment>>(payments, Messages.PaymentsListed);
        }

        public async Task<IDataResult<Payment>> GetSingleAsync(int id)
        {

            Payment bankTransfer = await _bankTransferDal.GetSingleAsync(c => c.Id == id);
            Payment creditCard = await _creditCardDal.GetSingleAsync(c => c.Id == id);

            Payment? payment = creditCard ?? bankTransfer;


            if (payment == null)
            {
                return new ErrorDataResult<Payment>(Messages.PaymentNotFound);
            }

            payment.PaymentType = payment is BankTransfer ? PaymentType.BankTransfer : PaymentType.CreditCard;

            return new SuccessDataResult<Payment>(payment);

        }
    }
}
