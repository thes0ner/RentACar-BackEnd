using RentACar.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Abstract
{
    public interface IVehicleTypeService
    {
        Task<IEnumerable<VehicleType>> GetVehicleTypesAsync();
        Task<VehicleType> GetSingleAsync(int id);
        Task AddAsync(VehicleType vehicleType);
        Task UpdateAsync(VehicleType vehicleType);
        Task DeleteAsync(VehicleType vehicleType);
    }
}
