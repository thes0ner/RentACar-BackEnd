using RentACar.Business.Abstract;
using RentACar.Business.Constants;
using RentACar.Entities.Concrete;
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
    public class FuelManager : IFuelService
    {
        private readonly IFuelDal _fuelDal;

        public FuelManager(IFuelDal fuelDal)
        {
            _fuelDal = fuelDal;
        }

        public async Task<IResult> AddAsync(Fuel fuel)
        {
            await _fuelDal.AddAsync(fuel);

            return new SuccessResult(Messages.FuelAdded);
        }

        public async Task<IResult> DeleteAsync(Fuel fuel)
        {
            await _fuelDal.DeleteAsync(fuel);

            return new SuccessResult(Messages.FuelDeleted);
        }

        public async Task<IResult> UpdateAsync(Fuel fuel)
        {
            await _fuelDal.UpdateAsync(fuel);

            return new SuccessResult(Messages.FuelUpdated);
        }

        public IDataResult<IQueryable<Fuel>> GetAllFuels()
        {
            var result = _fuelDal.GetAll();

            if (result == null || !result.Any())
            {
                return new ErrorDataResult<IQueryable<Fuel>>(Messages.FuelNotFound);
            }

            return new SuccessDataResult<IQueryable<Fuel>>(result, Messages.FuelsListed);
        }

        public async Task<IDataResult<Fuel>> GetSingleAsync(int id)
        {
            var result = await _fuelDal.GetSingleAsync(p => p.Id == id);

            if (result == null)
            {
                return new ErrorDataResult<Fuel>(Messages.FuelNotFound);
            }

            return new SuccessDataResult<Fuel>(result, Messages.FuelsListed);
        }


    }
}
