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
    public class FuelTypeManager : IFuelTypeService
    {
        private readonly IFuelTypeDal _fuelTypeDal;

        public FuelTypeManager(IFuelTypeDal fuelTypeDal)
        {
            _fuelTypeDal = fuelTypeDal;
        }

        public async Task<IResult> AddAsync(FuelType fuelType)
        {
            await _fuelTypeDal.AddAsync(fuelType);

            return new SuccessResult(Messages.FuelTypeAdded);
        }

        public async Task<IResult> DeleteAsync(FuelType fuelType)
        {
            await _fuelTypeDal.DeleteAsync(fuelType);

            return new SuccessResult(Messages.FuelTypeDeleted);
        }

        public async Task<IResult> UpdateAsync(FuelType fuelType)
        {
            await _fuelTypeDal.UpdateAsync(fuelType);

            return new SuccessResult(Messages.FuelTypeUpdated);
        }

        public async Task<IDataResult<IEnumerable<FuelType>>> GetFuelTypesAsync()
        {
            var result = await _fuelTypeDal.GetAllAsync();

            if (result == null)
            {
                return new ErrorDataResult<IEnumerable<FuelType>>(Messages.FuelTypeNotFound);
            }

            return new SuccessDataResult<IEnumerable<FuelType>>(result, Messages.FuelTypesListed);
        }

        public async Task<IDataResult<FuelType>> GetSingleAsync(int id)
        {
            var result = await _fuelTypeDal.GetSingleAsync(p => p.Id == id);

            if (result == null)
            {
                return new ErrorDataResult<FuelType>(Messages.FuelTypeNotFound);
            }

            return new SuccessDataResult<FuelType>(result, Messages.FuelTypesListed);
        }


    }
}
