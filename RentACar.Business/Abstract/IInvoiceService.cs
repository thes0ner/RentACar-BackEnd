using RentACar.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Abstract
{
    public interface IInvoiceService
    {
        Task<IEnumerable<Invoice>> GetInvoicesAsync();
        Task<Invoice> GetSingleAsync(int id);
        Task AddAsync(Invoice invoice);
        Task UpdateAsync(Invoice invoice);
        Task DeleteAsync(Invoice invoice);
    }
}
