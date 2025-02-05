using RentACar.Business.Abstract;
using RentACar.DataAccess.Abstract;
using RentACar.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Core.Entities.DTO_s;
using RentACar.Core.Utilities.Results.Abstract;
using RentACar.Core.Utilities.Results.Concrete;
using RentACar.Business.Constants;

namespace RentACar.Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public async Task<IDataResult<IEnumerable<Car>>> GetCarsAsync()
        {
            var result = await _carDal.GetAllAsync();

            if (result == null)
            {
                return new ErrorDataResult<IEnumerable<Car>>(Messages.CarNotFound);
            }

            return new SuccessDataResult<IEnumerable<Car>>(result, Messages.CarsListed);
        }

        public async Task<IDataResult<Car>> GetSingleAsync(int id)
        {
            var result = await _carDal.GetSingleAsync(p => p.Id == id);

            if (result == null)
            {
                return new ErrorDataResult<Car>(Messages.CarNotFound);
            }

            return new ErrorDataResult<Car>(result, Messages.CarsListed);
        }

        public async Task<IResult> AddAsync(Car car)
        {
            await _carDal.AddAsync(car);
            return new SuccessResult(Messages.CarAdded);
        }

        public async Task<IResult> UpdateAsync(Car car)
        {
            await _carDal.UpdateAsync(car);
            return new SuccessResult(Messages.CarUpdated);
        }

        public async Task<IResult> DeleteAsync(Car car)
        {
            await _carDal.DeleteAsync(car);
            return new SuccessResult(Messages.CarDeleted);
        }


        public async Task<List<CarDetailDto>> GetCarsDetailsAsync()
        {
            return await _carDal.GetCarsDetailsAsync();
        }

        public async Task<CarDetailDto> GetCarDetailsByIdAsync(int id)
        {
            return await _carDal.GetCarDetailsByIdAsync(id);
        }


        public async Task<List<CarDetailDto>> GetCarsByBrandAsync(string brandName)
        {
            return await _carDal.GetCarsByBrandAsync(brandName);
        }

        public async Task<List<CarDetailDto>> GetCarsByColorAsync(string colorName)
        {
            return await _carDal.GetCarsByColorAsync(colorName);
        }

        public async Task<List<CarDetailDto>> GetCarsByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            return await _carDal.GetCarsByPriceRangeAsync(minPrice, maxPrice);
        }
        public async Task<List<CarDetailDto>> GetCarsByAvailabilityAsync(CarStatus status)
        {
            return await _carDal.GetCarsByAvailabilityAsync(status);
        }

        public async Task<List<CarDetailDto>> GetCarsByModelYearAsync(int year)
        {
            return await _carDal.GetCarsByModelYearAsync(year);
        }

        public async Task<List<CarDetailDto>> GetCarsByFuelTypeAsync(string fuelType)
        {
            return await _carDal.GetCarsByFuelTypeAsync(fuelType);
        }

        public async Task<List<CarDetailDto>> GetCarsByTransmissionTypeAsync(string transmissionType)
        {
            return await _carDal.GetCarsByTransmissionTypeAsync(transmissionType);
        }

        public async Task<List<CarDetailDto>> GetCarsByModelYearRangeAsync(int minYear, int maxYear)
        {
            return await _carDal.GetCarsByModelYearRangeAsync(minYear, maxYear);
        }

        public async Task<List<CarDetailDto>> GetCarsByMileageRangeAsync(int minMileage, int maxMileage)
        {
            return await _carDal.GetCarsByMileageRangeAsync(minMileage, maxMileage);
        }


    }
}
