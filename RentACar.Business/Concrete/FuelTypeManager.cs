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
    public class FuelTypeManager : IFuelTypeService
    {
        private readonly IFuelTypeDal _fuelTypeDal;

        public FuelTypeManager(IFuelTypeDal fuelTypeDal)
        {
            _fuelTypeDal = fuelTypeDal;
        }

        public async Task AddAsync(FuelType fuelType)
        {
            await _fuelTypeDal.AddAsync(fuelType);
        }

        public async Task DeleteAsync(FuelType fuelType)
        {
            await _fuelTypeDal.DeleteAsync(fuelType);
        }

        public async Task<IEnumerable<FuelType>> GetFuelTypesAsync()
        {
            return await _fuelTypeDal.GetAllAsync();
        }

        public async Task<FuelType> GetSingleAsync(int id)
        {
            return await _fuelTypeDal.GetSingleAsync(c => c.Id == id);
        }

        public async Task UpdateAsync(FuelType fuelType)
        {
            await _fuelTypeDal.UpdateAsync(fuelType);
        }
    }
}
