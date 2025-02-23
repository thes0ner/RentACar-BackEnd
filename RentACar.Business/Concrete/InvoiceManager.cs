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
    public class InvoiceManager : IInvoiceService
    {
        private readonly IInvoiceDal _invoiceDal;

        public InvoiceManager(IInvoiceDal invoiceDal)
        {
            _invoiceDal = invoiceDal;
        }

        public async Task<IResult> AddAsync(Invoice invoice)
        {
            await _invoiceDal.AddAsync(invoice);
            return new SuccessResult(Messages.InvoiceAdded);
        }

        public async Task<IResult> DeleteAsync(Invoice invoice)
        {
            await _invoiceDal.DeleteAsync(invoice);
            return new SuccessResult(Messages.InvoiceDeleted);
        }

        public async Task<IResult> UpdateAsync(Invoice invoice)
        {
            await _invoiceDal.UpdateAsync(invoice);
            return new SuccessResult(Messages.InvoiceUpdated);
        }

        public IDataResult<IQueryable<Invoice>> GetAllInvoices()
        {
            var result = _invoiceDal.GetAll();

            if (result == null || !result.Any())
            {
                return new ErrorDataResult<IQueryable<Invoice>>(Messages.InvoiceNotFound);
            }

            return new SuccessDataResult<IQueryable<Invoice>>(result, Messages.InvoicesListed);
        }

        public async Task<IDataResult<Invoice>> GetSingleAsync(int id)
        {
            var result = await _invoiceDal.GetSingleAsync(p => p.Id == id);

            if (result == null)
            {
                return new ErrorDataResult<Invoice>(Messages.InvoiceNotFound);
            }

            return new SuccessDataResult<Invoice>(result, Messages.InvoicesListed);
        }


    }
}
