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
    public class VehicleTypeManager : IVehicleTypeService
    {
        private readonly IVehicleTypeDal _vehicleTypeDal;

        public VehicleTypeManager(IVehicleTypeDal vehicleTypeDal)
        {
            _vehicleTypeDal = vehicleTypeDal;
        }

        public async Task AddAsync(VehicleType vehicleType)
        {
            await _vehicleTypeDal.AddAsync(vehicleType);
        }

        public async Task DeleteAsync(VehicleType vehicleType)
        {
            await _vehicleTypeDal.DeleteAsync(vehicleType);
        }

        public async Task UpdateAsync(VehicleType vehicleType)
        {
            await _vehicleTypeDal.UpdateAsync(vehicleType);
        }

        public async Task<VehicleType> GetSingleAsync(int id)
        {
            return await _vehicleTypeDal.GetSingleAsync(v => v.Id == id);
        }

        public async Task<IEnumerable<VehicleType>> GetVehicleTypesAsync()
        {
            return await _vehicleTypeDal.GetAllAsync();
        }

    }
}
