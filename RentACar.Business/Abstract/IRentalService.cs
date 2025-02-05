using RentACar.Core.Entities.Concrete;
using RentACar.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Abstract
{
    public interface IRentalService
    {
        Task<IDataResult<IEnumerable<Rental>>> GetRentalsAsync();
        Task<IDataResult<Rental>> GetSingleAsync(int id);
        Task<IResult> AddAsync(Rental rental);
        Task<IResult> UpdateAsync(Rental rental);
        Task<IResult> DeleteAsync(Rental rental);

    }
}
