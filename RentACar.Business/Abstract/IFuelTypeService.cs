using RentACar.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Abstract
{
    public interface IFuelTypeService
    {
        Task<IEnumerable<FuelType>> GetFuelTypesAsync();
        Task<FuelType> GetSingleAsync(int id);
        Task AddAsync(FuelType fuelType);
        Task UpdateAsync(FuelType fuelType);
        Task DeleteAsync(FuelType fuelType);
    }
}
