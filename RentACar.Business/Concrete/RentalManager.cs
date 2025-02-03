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
    public class RentalManager : IRentalService
    {
        private readonly IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public async Task AddAsync(Rental rental)
        {
            await _rentalDal.AddAsync(rental);
        }

        public async Task DeleteAsync(Rental rental)
        {
            await _rentalDal.DeleteAsync(rental);
        }

        public async Task UpdateAsync(Rental rental)
        {
            await _rentalDal.UpdateAsync(rental);
        }

        public async Task<IEnumerable<Rental>> GetRentalsAsync()
        {
            return await _rentalDal.GetAllAsync();
        }

        public async Task<Rental> GetSingleAsync(int id)
        {
            return await _rentalDal.GetSingleAsync(r => r.Id == id);
        }

    }
}
