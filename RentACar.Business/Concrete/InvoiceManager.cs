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
    public class InvoiceManager : IInvoiceService
    {
        private readonly IInvoiceDal _invoiceDal;

        public InvoiceManager(IInvoiceDal invoiceDal)
        {
            _invoiceDal = invoiceDal;
        }

        public async Task AddAsync(Invoice invoice)
        {
            await _invoiceDal.AddAsync(invoice);
        }

        public async Task DeleteAsync(Invoice invoice)
        {
            await _invoiceDal.DeleteAsync(invoice);
        }

        public async Task UpdateAsync(Invoice invoice)
        {
            await _invoiceDal.UpdateAsync(invoice);
        }

        public async Task<IEnumerable<Invoice>> GetInvoicesAsync()
        {
           return await _invoiceDal.GetAllAsync();
        }

        public async Task<Invoice> GetSingleAsync(int id)
        {
            return await _invoiceDal.GetSingleAsync(i => i.Id == id);
        }


    }
}
