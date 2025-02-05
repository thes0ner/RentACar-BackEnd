using RentACar.Core.Entities.Concrete;
using RentACar.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Abstract
{
    public interface ILocationService
    {
        Task<IDataResult<IEnumerable<Location>>> GetLocationsAsync();
        Task<IDataResult<Location>> GetSingleAsync(int id);
        Task<IResult> AddAsync(Location location);
        Task<IResult> UpdateAsync(Location location);
        Task<IResult> DeleteAsync(Location location);
    }
}
