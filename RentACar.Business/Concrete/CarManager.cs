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


        public IDataResult<IQueryable<Car>> GetAllCars()
        {
            var result = _carDal.GetAll();

            if (result == null || !result.Any())
            {
                return new ErrorDataResult<IQueryable<Car>>(Messages.CarNotFound);
            }

            return new SuccessDataResult<IQueryable<Car>>(result, Messages.CarsListed);
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

        public async Task<IDataResult<CarDetailDto>> GetCarDetailsByIdAsync(int id)
        {
            var result = await _carDal.GetCarDetailsByIdAsync(id);

            if (result == null)
            {
                return new ErrorDataResult<CarDetailDto>(Messages.CarNotFound);
            }

            return new SuccessDataResult<CarDetailDto>(result, Messages.CarsListed);

        }

        public async Task<IDataResult<IEnumerable<CarDetailDto>>> GetCarsDetailsAsync()
        {
            var result = await _carDal.GetCarsDetailsAsync();

            if (result == null)
            {
                return new ErrorDataResult<IEnumerable<CarDetailDto>>(Messages.CarNotFound);
            }

            return new SuccessDataResult<IEnumerable<CarDetailDto>>(result, Messages.CarsListed);
        }


        public async Task<IDataResult<IEnumerable<CarDetailDto>>> GetCarsByBrandAsync(string brandName)
        {
            var result = await _carDal.GetCarsByBrandAsync(brandName);

            if (result == null)
            {
                return new ErrorDataResult<IEnumerable<CarDetailDto>>(Messages.CarNotFound);
            }

            return new SuccessDataResult<IEnumerable<CarDetailDto>>(result, Messages.CarsListed);
        }

        public async Task<IDataResult<IEnumerable<CarDetailDto>>> GetCarsByColorAsync(string colorName)
        {
            var result = await _carDal.GetCarsByColorAsync(colorName);

            if (result == null)
            {
                return new ErrorDataResult<IEnumerable<CarDetailDto>>(Messages.CarNotFound);
            }

            return new SuccessDataResult<IEnumerable<CarDetailDto>>(result, Messages.CarsListed);
        }

        public async Task<IDataResult<IEnumerable<CarDetailDto>>> GetCarsByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            var result = await _carDal.GetCarsByPriceRangeAsync(minPrice, maxPrice);

            if (result == null)
            {
                return new ErrorDataResult<IEnumerable<CarDetailDto>>(Messages.CarNotFound);
            }

            return new SuccessDataResult<IEnumerable<CarDetailDto>>(result, Messages.CarsListed);
        }

        public async Task<IDataResult<IEnumerable<CarDetailDto>>> GetCarsByAvailabilityAsync(CarStatus status)
        {
            var result = await _carDal.GetCarsByAvailabilityAsync(status);

            if (result == null)
            {
                return new ErrorDataResult<IEnumerable<CarDetailDto>>(Messages.CarNotFound);
            }

            return new SuccessDataResult<IEnumerable<CarDetailDto>>(result, Messages.CarsListed);
        }

        public async Task<IDataResult<IEnumerable<CarDetailDto>>> GetCarsByModelYearAsync(int year)
        {
            var result = await _carDal.GetCarsByModelYearAsync(year);

            if (result == null)
            {
                return new ErrorDataResult<IEnumerable<CarDetailDto>>(Messages.CarNotFound);
            }

            return new SuccessDataResult<IEnumerable<CarDetailDto>>(result, Messages.CarsListed);
        }

        public async Task<IDataResult<IEnumerable<CarDetailDto>>> GetCarsByFuelTypeAsync(string fuelType)
        {
            var result = await _carDal.GetCarsByFuelTypeAsync(fuelType);

            if (result == null)
            {
                return new ErrorDataResult<IEnumerable<CarDetailDto>>(Messages.CarNotFound);
            }

            return new SuccessDataResult<IEnumerable<CarDetailDto>>(result, Messages.CarsListed);
        }

        public async Task<IDataResult<IEnumerable<CarDetailDto>>> GetCarsByTransmissionTypeAsync(string transmissionType)
        {
            var result = await _carDal.GetCarsByTransmissionTypeAsync(transmissionType);

            if (result == null)
            {
                return new ErrorDataResult<IEnumerable<CarDetailDto>>(Messages.CarNotFound);
            }

            return new SuccessDataResult<IEnumerable<CarDetailDto>>(result, Messages.CarsListed);

        }

        public async Task<IDataResult<IEnumerable<CarDetailDto>>> GetCarsByModelYearRangeAsync(int minYear, int maxYear)
        {
            var result = await _carDal.GetCarsByModelYearRangeAsync(minYear, maxYear);

            if (result == null)
            {
                return new ErrorDataResult<IEnumerable<CarDetailDto>>(Messages.CarNotFound);
            }

            return new SuccessDataResult<IEnumerable<CarDetailDto>>(result, Messages.CarsListed);
        }


        // burdan sonra ....
        public async Task<IDataResult<IEnumerable<CarDetailDto>>> GetCarsByMileageRangeAsync(int minMileage, int maxMileage)
        {
            var result = await _carDal.GetCarsByMileageRangeAsync(minMileage, maxMileage);

            if (result == null)
            {
                return new ErrorDataResult<IEnumerable<CarDetailDto>>(Messages.CarNotFound);
            }

            return new SuccessDataResult<IEnumerable<CarDetailDto>>(result, Messages.CarsListed);
        }

        public IDataResult<Dictionary<object, IQueryable<CarDetailDto>>> GetCarsGroupByBrand(string brandName)
        {
            var result = _carDal.GetGroupedCars(
                groupBy: c => c.BrandName,
                filter: c => c.BrandName == brandName
            );

            if (result == null || !result.Any())
            {
                return new ErrorDataResult<Dictionary<object, IQueryable<CarDetailDto>>>(Messages.CarNotFound);
            }

            return new SuccessDataResult<Dictionary<object, IQueryable<CarDetailDto>>>(result, Messages.CarsListed);
        }

        public IDataResult<Dictionary<object, IQueryable<CarDetailDto>>> GetCarsGroupByColor(string colorName)
        {
            var result = _carDal.GetGroupedCars(groupBy: c => c.ColorName, filter: c => c.ColorName == colorName);

            if (result == null || !result.Any())
            {
                return new ErrorDataResult<Dictionary<object, IQueryable<CarDetailDto>>>(Messages.CarNotFound);
            }

            return new SuccessDataResult<Dictionary<object, IQueryable<CarDetailDto>>>(result, Messages.CarsListed);

        }

        public IDataResult<Dictionary<object, IQueryable<CarDetailDto>>> GetCarsGroupByFuel(string fuel)
        {
            var result = _carDal.GetGroupedCars(groupBy: c => c.Fuel, filter: c => c.Fuel == fuel);

            if (result == null || !result.Any())
            {
                return new ErrorDataResult<Dictionary<object, IQueryable<CarDetailDto>>>(Messages.CarNotFound);
            }

            return new SuccessDataResult<Dictionary<object, IQueryable<CarDetailDto>>>(result, Messages.CarsListed);
        }

        public IDataResult<Dictionary<object, IQueryable<CarDetailDto>>> GetCarsGroupByTransmission(string transmission)
        {
            var result = _carDal.GetGroupedCars(groupBy: c => c.Transmission, filter: c => c.Transmission == transmission);


            if (result == null || !result.Any())
            {
                return new ErrorDataResult<Dictionary<object, IQueryable<CarDetailDto>>>(Messages.CarNotFound);
            }

            return new SuccessDataResult<Dictionary<object, IQueryable<CarDetailDto>>>(result, Messages.CarsListed);
        }

        public IDataResult<Dictionary<object, IQueryable<CarDetailDto>>> GetCarsGroupByVehicle(string vehicle)
        {
            var result = _carDal.GetGroupedCars(groupBy: c => c.Vehicle, filter: c => c.Vehicle == vehicle);

            if (result == null || !result.Any())
            {
                return new ErrorDataResult<Dictionary<object, IQueryable<CarDetailDto>>>(Messages.CarNotFound);
            }

            return new SuccessDataResult<Dictionary<object, IQueryable<CarDetailDto>>>(result, Messages.CarsListed);

        }

        public IDataResult<Dictionary<object, IQueryable<CarDetailDto>>> GetCarsGroupByDailyPrice(decimal dailyPrice)
        {
            var result = _carDal.GetGroupedCars(groupBy: c => c.DailyPrice, filter: c => c.DailyPrice == dailyPrice);

            if (result == null || !result.Any())
            {
                return new ErrorDataResult<Dictionary<object, IQueryable<CarDetailDto>>>(Messages.CarNotFound);
            }

            return new SuccessDataResult<Dictionary<object, IQueryable<CarDetailDto>>>(result, Messages.CarsListed);
        }

        public IDataResult<Dictionary<object, IQueryable<CarDetailDto>>> GetCarsGroupByModel(string model)
        {
            var result = _carDal.GetGroupedCars(groupBy: c => c.Model, filter: c => c.Model == model);

            if (result == null || !result.Any())
            {
                return new ErrorDataResult<Dictionary<object, IQueryable<CarDetailDto>>>(Messages.CarNotFound);
            }

            return new SuccessDataResult<Dictionary<object, IQueryable<CarDetailDto>>>(result, Messages.CarsListed);
        }

        public IDataResult<Dictionary<object, IQueryable<CarDetailDto>>> GetCarsGroupByYear(int year)
        {
            var result = _carDal.GetGroupedCars(groupBy: c => c.Year, filter: c => c.Year == year);

            if (result == null || !result.Any())
            {
                return new ErrorDataResult<Dictionary<object, IQueryable<CarDetailDto>>>(Messages.CarNotFound);
            }

            return new SuccessDataResult<Dictionary<object, IQueryable<CarDetailDto>>>(result, Messages.CarsListed);
        }

        public IDataResult<Dictionary<object, IQueryable<CarDetailDto>>> GetCarsGroupByAvailability(CarStatus status)
        {
            var result = _carDal.GetGroupedCars(groupBy: c => c.Status, filter: c => c.Status == status);

            if (result == null || !result.Any())
            {
                return new ErrorDataResult<Dictionary<object, IQueryable<CarDetailDto>>>(Messages.CarNotFound);
            }

            return new SuccessDataResult<Dictionary<object, IQueryable<CarDetailDto>>>(result, Messages.CarsListed);
        }

    }
}
