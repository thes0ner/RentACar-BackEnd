using RentACar.Business.Abstract;
using RentACar.Business.Constants;
using RentACar.Core.Entities.Concrete;
using RentACar.Core.Utilities.Results.Abstract;
using RentACar.Core.Utilities.Results.Concrete;
using RentACar.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Concrete
{
    public class VehicleManager : IVehicleService
    {
        private readonly IVehicleDal _vehicleDal;

        public VehicleManager(IVehicleDal vehicleDal)
        {
            _vehicleDal = vehicleDal;
        }

        public async Task<IResult> AddAsync(Vehicle vehicle)
        {
            await _vehicleDal.AddAsync(vehicle);
            return new SuccessResult(Messages.VehicleTypeAdded);
        }

        public async Task<IResult> DeleteAsync(Vehicle vehicle)
        {
            await _vehicleDal.DeleteAsync(vehicle);
            return new SuccessResult(Messages.VehicleTypeAdded);

        }

        public async Task<IResult> UpdateAsync(Vehicle vehicleType)
        {
            await _vehicleDal.UpdateAsync(vehicleType);
            return new SuccessResult(Messages.VehicleTypeUpdated);
        }

        public async Task<IDataResult<Vehicle>> GetSingleAsync(int id)
        {
            var result = await _vehicleDal.GetSingleAsync(p => p.Id == id);

            if (result == null)
            {
                return new ErrorDataResult<Vehicle>(Messages.VehicleTypeNotFound);
            }

            return new SuccessDataResult<Vehicle>(result, Messages.VehicleTypesListed);
        }

        public IDataResult<IQueryable<Vehicle>> GetAllVehicles()
        {
            var result = _vehicleDal.GetAll();

            if (result == null || !result.Any())
            {
                return new ErrorDataResult<IQueryable<Vehicle>>(Messages.VehicleTypeNotFound);
            }

            return new SuccessDataResult<IQueryable<Vehicle>>(result, Messages.VehicleTypesListed);
        }


    }
}
