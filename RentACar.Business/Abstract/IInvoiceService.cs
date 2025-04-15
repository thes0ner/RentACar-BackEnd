using RentACar.Entities.Concrete;
using RentACar.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Entities.DTO;

namespace RentACar.Business.Abstract
{
    public interface IInvoiceService
    {
        IDataResult<IQueryable<Invoice>> GetAllInvoices();
        Task<IDataResult<Invoice>> GetSingleAsync(int id);
        Task<IResult> AddAsync(InvoiceDto invoiceDto);
        Task<IResult> UpdateAsync(InvoiceDto invoiceDto);
        Task<IResult> DeleteAsync(Invoice invoice);
    }
}
