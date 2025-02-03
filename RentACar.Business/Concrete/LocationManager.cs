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
    public class LocationManager : ILocationService
    {
        private readonly ILocationDal _locationDal;

        public LocationManager(ILocationDal locationDal)
        {
            _locationDal = locationDal;
        }

        public async Task AddAsync(Location location)
        {
            await _locationDal.AddAsync(location);
        }

        public async Task DeleteAsync(Location location)
        {
            await _locationDal.DeleteAsync(location);
        }

        public async Task UpdateAsync(Location location)
        {
            await _locationDal.UpdateAsync(location);
        }

        public async Task<IEnumerable<Location>> GetLocationsAsync()
        {
            return await _locationDal.GetAllAsync();
        }

        public async Task<Location> GetSingleAsync(int id)
        {
            return await _locationDal.GetSingleAsync(c => c.Id == id);
        }


    }
}
