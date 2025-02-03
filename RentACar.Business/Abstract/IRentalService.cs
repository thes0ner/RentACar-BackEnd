using RentACar.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Abstract
{
    public interface IRentalService
    {
        Task<IEnumerable<Rental>> GetRentalsAsync();
        Task<Rental> GetSingleAsync(int id);
        Task AddAsync(Rental rental);
        Task UpdateAsync(Rental rental);
        Task DeleteAsync(Rental rental);

    }
}
