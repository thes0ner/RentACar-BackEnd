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
    public class LocationManager : ILocationService
    {
        private readonly ILocationDal _locationDal;

        public LocationManager(ILocationDal locationDal)
        {
            _locationDal = locationDal;
        }

        public async Task<IResult> AddAsync(Location location)
        {
            await _locationDal.AddAsync(location);
            return new SuccessResult(Messages.LocationAdded);
        }

        public async Task<IResult> DeleteAsync(Location location)
        {
            await _locationDal.DeleteAsync(location);
            return new SuccessResult(Messages.LocationDeleted);
        }

        public async Task<IResult> UpdateAsync(Location location)
        {
            await _locationDal.UpdateAsync(location);
            return new SuccessResult(Messages.LocationUpdated);
        }

        public IDataResult<IQueryable<Location>> GetAllLocations()
        {
            var result = _locationDal.GetAll();

            if (result == null || !result.Any())
            {
                return new ErrorDataResult<IQueryable<Location>>(Messages.LocationNotFound);
            }

            return new SuccessDataResult<IQueryable<Location>>(result, Messages.LocationsListed);
        }

        public async Task<IDataResult<Location>> GetSingleAsync(int id)
        {
            var result = await _locationDal.GetSingleAsync(p => p.Id == id);

            if (result == null)
            {
                return new ErrorDataResult<Location>(Messages.LocationNotFound);
            }

            return new SuccessDataResult<Location>(result, Messages.LocationsListed);
        }


    }
}
