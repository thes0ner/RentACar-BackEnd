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
    public class VehicleTypeManager : IVehicleTypeService
    {
        private readonly IVehicleTypeDal _vehicleTypeDal;

        public VehicleTypeManager(IVehicleTypeDal vehicleTypeDal)
        {
            _vehicleTypeDal = vehicleTypeDal;
        }

        public async Task<IResult> AddAsync(VehicleType vehicleType)
        {
            await _vehicleTypeDal.AddAsync(vehicleType);
            return new SuccessResult(Messages.VehicleTypeAdded);
        }

        public async Task<IResult> DeleteAsync(VehicleType vehicleType)
        {
            await _vehicleTypeDal.DeleteAsync(vehicleType);
            return new SuccessResult(Messages.VehicleTypeAdded);

        }

        public async Task<IResult> UpdateAsync(VehicleType vehicleType)
        {
            await _vehicleTypeDal.UpdateAsync(vehicleType);
            return new SuccessResult(Messages.TransmissionTypeUpdated);
        }

        public async Task<IDataResult<VehicleType>> GetSingleAsync(int id)
        {
            var result = await _vehicleTypeDal.GetSingleAsync(p => p.Id == id);

            if (result == null)
            {
                return new ErrorDataResult<VehicleType>(Messages.VehicleTypeNotFound);
            }

            return new SuccessDataResult<VehicleType>(result, Messages.VehicleTypesListed);
        }

        public async Task<IDataResult<IEnumerable<VehicleType>>> GetVehicleTypesAsync()
        {
            var result = await _vehicleTypeDal.GetAllAsync();

            if (result == null)
            {
                return new ErrorDataResult<IEnumerable<VehicleType>>(Messages.VehicleTypeNotFound);
            }

            return new SuccessDataResult<IEnumerable<VehicleType>>(result, Messages.VehicleTypesListed);
        }


    }
}
