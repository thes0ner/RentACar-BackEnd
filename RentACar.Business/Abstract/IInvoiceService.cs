using RentACar.Core.Entities.Concrete;
using RentACar.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Abstract
{
    public interface IInvoiceService
    {
        Task<IDataResult<IEnumerable<Invoice>>> GetInvoicesAsync();
        Task<IDataResult<Invoice>> GetSingleAsync(int id);
        Task<IResult> AddAsync(Invoice invoice);
        Task<IResult> UpdateAsync(Invoice invoice);
        Task<IResult> DeleteAsync(Invoice invoice);
    }
}
