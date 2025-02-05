using RentACar.Core.Entities.Concrete;
using RentACar.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Abstract
{
    public interface IFuelTypeService
    {
        Task<IDataResult<IEnumerable<FuelType>>> GetFuelTypesAsync();
        Task<IDataResult<FuelType>> GetSingleAsync(int id);
        Task<IResult> AddAsync(FuelType fuelType);
        Task<IResult> UpdateAsync(FuelType fuelType);
        Task<IResult> DeleteAsync(FuelType fuelType);
    }
}
