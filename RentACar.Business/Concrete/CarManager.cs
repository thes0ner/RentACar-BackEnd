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

        public async Task<IDataResult<IEnumerable<CarDetailDto>>> GetCarsByMileageRangeAsync(int minMileage, int maxMileage)
        {
            var result = await _carDal.GetCarsByMileageRangeAsync(minMileage, maxMileage);

            if (result == null)
            {
                return new ErrorDataResult<IEnumerable<CarDetailDto>>(Messages.CarNotFound);
            }

            return new SuccessDataResult<IEnumerable<CarDetailDto>>(result, Messages.CarsListed);
        }

        public async Task<IDataResult<Dictionary<object, IEnumerable<CarDetailDto>>>> GetCarsGroupByBrandAsync(string brandName)
        {
            var result = await _carDal.GetCarsGroupedAsync(
                groupBy: c => c.BrandName,
                filter: c => c.BrandName == brandName
            );

            if (result == null || !result.Any())
            {
                return new ErrorDataResult<Dictionary<object, IEnumerable<CarDetailDto>>>(Messages.CarNotFound);
            }

            return new SuccessDataResult<Dictionary<object, IEnumerable<CarDetailDto>>>(result, Messages.CarsListed);
        }

        public async Task<IDataResult<Dictionary<object, IEnumerable<CarDetailDto>>>> GetCarsGroupByColorAsync(string colorName)
        {
            var result = await _carDal.GetCarsGroupedAsync(groupBy: c => c.ColorName, filter: c => c.ColorName == colorName);

            if (result == null || !result.Any())
            {
                return new ErrorDataResult<Dictionary<object, IEnumerable<CarDetailDto>>>(Messages.CarNotFound);
            }

            return new SuccessDataResult<Dictionary<object, IEnumerable<CarDetailDto>>>(result, Messages.CarsListed);

        }

        public async Task<IDataResult<Dictionary<object, IEnumerable<CarDetailDto>>>> GetCarsGroupByFuleTypeAsync(string fuelType)
        {
            var result = await _carDal.GetCarsGroupedAsync(groupBy: c => c.FuelType, filter: c => c.FuelType == fuelType);

            if (result == null || !result.Any())
            {
                return new ErrorDataResult<Dictionary<object, IEnumerable<CarDetailDto>>>(Messages.CarNotFound);
            }

            return new SuccessDataResult<Dictionary<object, IEnumerable<CarDetailDto>>>(result, Messages.CarsListed);
        }

        public async Task<IDataResult<Dictionary<object, IEnumerable<CarDetailDto>>>> GetCarsGroupByTransmissionTypeAsync(string transmissionType)
        {
            var result = await _carDal.GetCarsGroupedAsync(groupBy: c => c.TransmissionType, filter: c => c.TransmissionType == transmissionType);


            if (result == null || !result.Any())
            {
                return new ErrorDataResult<Dictionary<object, IEnumerable<CarDetailDto>>>(Messages.CarNotFound);
            }

            return new SuccessDataResult<Dictionary<object, IEnumerable<CarDetailDto>>>(result, Messages.CarsListed);
        }

        public async Task<IDataResult<Dictionary<object, IEnumerable<CarDetailDto>>>> GetCarsGroupByVehicleTypeAsync(string vehicleType)
        {
            var result = await _carDal.GetCarsGroupedAsync(groupBy: c => c.VehicleType, filter: c => c.VehicleType == vehicleType);

            if (result == null || !result.Any())
            {
                return new ErrorDataResult<Dictionary<object, IEnumerable<CarDetailDto>>>(Messages.CarNotFound);
            }

            return new SuccessDataResult<Dictionary<object, IEnumerable<CarDetailDto>>>(result, Messages.CarsListed);

        }

        public async Task<IDataResult<Dictionary<object, IEnumerable<CarDetailDto>>>> GetCarsGroupByDailyPriceAsync(decimal dailyPrice)
        {
            var result = await _carDal.GetCarsGroupedAsync(groupBy: c => c.DailyPrice, filter: c => c.DailyPrice == dailyPrice);

            if (result == null || !result.Any())
            {
                return new ErrorDataResult<Dictionary<object, IEnumerable<CarDetailDto>>>(Messages.CarNotFound);
            }

            return new SuccessDataResult<Dictionary<object, IEnumerable<CarDetailDto>>>(result, Messages.CarsListed);
        }

        public async Task<IDataResult<Dictionary<object, IEnumerable<CarDetailDto>>>> GetCarsGroupByModelAsync(string model)
        {
            var result = await _carDal.GetCarsGroupedAsync(groupBy: c => c.Model, filter: c => c.Model == model);

            if (result == null || !result.Any())
            {
                return new ErrorDataResult<Dictionary<object, IEnumerable<CarDetailDto>>>(Messages.CarNotFound);
            }

            return new SuccessDataResult<Dictionary<object, IEnumerable<CarDetailDto>>>(result, Messages.CarsListed);
        }

        public async Task<IDataResult<Dictionary<object, IEnumerable<CarDetailDto>>>> GetCarsGroupByYearAsync(int year)
        {
            var result = await _carDal.GetCarsGroupedAsync(groupBy: c => c.Year, filter: c => c.Year == year);

            if (result == null || !result.Any())
            {
                return new ErrorDataResult<Dictionary<object, IEnumerable<CarDetailDto>>>(Messages.CarNotFound);
            }

            return new SuccessDataResult<Dictionary<object, IEnumerable<CarDetailDto>>>(result, Messages.CarsListed);
        }

        public async Task<IDataResult<Dictionary<object, IEnumerable<CarDetailDto>>>> GetCarsGroupByAvailabilityAsync(CarStatus status)
        {
            var result = await _carDal.GetCarsGroupedAsync(groupBy: c => c.Status, filter: c => c.Status == status);

            if (result == null || !result.Any())
            {
                return new ErrorDataResult<Dictionary<object, IEnumerable<CarDetailDto>>>(Messages.CarNotFound);
            }

            return new SuccessDataResult<Dictionary<object, IEnumerable<CarDetailDto>>>(result, Messages.CarsListed);
        }
    }
}
