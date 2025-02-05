using RentACar.Core.Entities.Concrete;
using RentACar.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Abstract
{
    public interface IVehicleTypeService
    {
        Task<IDataResult<IEnumerable<VehicleType>>> GetVehicleTypesAsync();
        Task<IDataResult<VehicleType>> GetSingleAsync(int id);
        Task<IResult> AddAsync(VehicleType vehicleType);
        Task<IResult> UpdateAsync(VehicleType vehicleType);
        Task<IResult> DeleteAsync(VehicleType vehicleType);
    }
}
