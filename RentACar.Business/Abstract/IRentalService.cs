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
    public interface IRentalService
    {
        IDataResult<IQueryable<Rental>> GetAllRentals();
        Task<IDataResult<Rental>> GetSingleAsync(int id);
        Task<IResult> AddAsync(RentalDto rentalDto);
        Task<IResult> UpdateAsync(RentalDto rentalDto);
        Task<IResult> DeleteAsync(Rental rental);

    }
}
