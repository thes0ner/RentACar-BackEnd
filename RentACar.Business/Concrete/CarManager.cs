using RentACar.Business.Abstract;
using RentACar.DataAccess.Abstract;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Core.Utilities.Results.Abstract;
using RentACar.Core.Utilities.Results.Concrete;
using RentACar.Business.Constants;
using RentACar.Entities.Enums;
using RentACar.DataAccess.Concrete.EntityFramework;
using AutoMapper;
using RentACar.Entities.DTO;

namespace RentACar.Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;
        private readonly IMapper _mapper;

        public CarManager(ICarDal carDal, IMapper mapper)
        {
            _carDal = carDal;
            _mapper = mapper;
        }

        public async Task<IResult> AddAsync(CarDto carDto)
        {

            var plateCheck = await CheckIfPlateExist(carDto.Plate);

            if (plateCheck != null)
            {
                return plateCheck;
            }

            var car = _mapper.Map<Car>(carDto);

            await _carDal.AddAsync(car);

            return new SuccessResult(Messages.CarAdded);
        }

        public async Task<IResult> UpdateAsync(CarDto carDto)
        {

            var car = await _carDal.GetSingleAsync(c => c.Id == carDto.Id);

            if (car == null)
                return new ErrorResult(Messages.CarNotFound);


            _mapper.Map(carDto, car);

            await _carDal.UpdateAsync(car);
            return new SuccessResult(Messages.CarUpdated);
        }


        public async Task<IResult> DeleteAsync(Car car)
        {
            await _carDal.DeleteAsync(car);
            return new SuccessResult(Messages.CarDeleted);
        }


        //Query methods

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

            return new SuccessDataResult<Car>(result, Messages.CarsListed);
        }



        public async Task<IDataResult<CarDetailDto>> GetCarDetailById(int id)
        {
            var result = await _carDal.GetCarDetailById(id);

            if (result == null)
            {
                return new ErrorDataResult<CarDetailDto>(Messages.CarNotFound);
            }

            return new SuccessDataResult<CarDetailDto>(result, Messages.CarsListed);

        }

        public IDataResult<IQueryable<CarDetailDto>> GetCarDetails()
        {
            var result = _carDal.GetCarDetails();

            if (result == null)
            {
                return new ErrorDataResult<IQueryable<CarDetailDto>>(Messages.CarNotFound);
            }

            return new SuccessDataResult<IQueryable<CarDetailDto>>(result, Messages.CarsListed);
        }


        public IDataResult<IQueryable<CarDetailDto>> GetCarsByBrandName(string brandName)
        {
            var result = _carDal.GetCarsByBrandName(brandName);

            if (result == null)
            {
                return new ErrorDataResult<IQueryable<CarDetailDto>>(Messages.CarNotFound);
            }

            return new SuccessDataResult<IQueryable<CarDetailDto>>(result, Messages.CarsListed);
        }

        public IDataResult<IQueryable<CarDetailDto>> GetCarsByColorName(string colorName)
        {
            var result = _carDal.GetCarsByColorName(colorName);

            if (result == null)
            {
                return new ErrorDataResult<IQueryable<CarDetailDto>>(Messages.CarNotFound);
            }

            return new SuccessDataResult<IQueryable<CarDetailDto>>(result, Messages.CarsListed);
        }

        public IDataResult<IQueryable<CarDetailDto>> GetCarsByPriceRange(decimal minPrice, decimal maxPrice)
        {
            var result = _carDal.GetCarsByPriceRange(minPrice, maxPrice);

            if (result == null)
            {
                return new ErrorDataResult<IQueryable<CarDetailDto>>(Messages.CarNotFound);
            }

            return new SuccessDataResult<IQueryable<CarDetailDto>>(result, Messages.CarsListed);
        }

        public IDataResult<IQueryable<CarDetailDto>> GetCarsByAvailability(CarStatus status)
        {
            var result = _carDal.GetCarsByAvailability(status);

            if (result == null)
            {
                return new ErrorDataResult<IQueryable<CarDetailDto>>(Messages.CarNotFound);
            }

            return new SuccessDataResult<IQueryable<CarDetailDto>>(result, Messages.CarsListed);
        }

        public IDataResult<IQueryable<CarDetailDto>> GetCarsByModelYear(int year)
        {
            var result = _carDal.GetCarsByModelYear(year);

            if (result == null)
            {
                return new ErrorDataResult<IQueryable<CarDetailDto>>(Messages.CarNotFound);
            }

            return new SuccessDataResult<IQueryable<CarDetailDto>>(result, Messages.CarsListed);
        }

        public IDataResult<IQueryable<CarDetailDto>> GetCarsByFuelType(string fuelType)
        {
            var result = _carDal.GetCarsByFuelType(fuelType);

            if (result == null)
            {
                return new ErrorDataResult<IQueryable<CarDetailDto>>(Messages.CarNotFound);
            }

            return new SuccessDataResult<IQueryable<CarDetailDto>>(result, Messages.CarsListed);
        }

        public IDataResult<IQueryable<CarDetailDto>> GetCarsByTransmissionType(string transmissionType)
        {
            var result = _carDal.GetCarsByTransmissionType(transmissionType);

            if (result == null)
            {
                return new ErrorDataResult<IQueryable<CarDetailDto>>(Messages.CarNotFound);
            }

            return new SuccessDataResult<IQueryable<CarDetailDto>>(result, Messages.CarsListed);

        }

        public IDataResult<IQueryable<CarDetailDto>> GetCarsByModelYearRange(int minYear, int maxYear)
        {
            var result = _carDal.GetCarsByModelYearRange(minYear, maxYear);

            if (result == null)
            {
                return new ErrorDataResult<IQueryable<CarDetailDto>>(Messages.CarNotFound);
            }

            return new SuccessDataResult<IQueryable<CarDetailDto>>(result, Messages.CarsListed);
        }

        public IDataResult<IQueryable<CarDetailDto>> GetCarsByMileageRange(int minMileage, int maxMileage)
        {
            var result = _carDal.GetCarsByMileageRange(minMileage, maxMileage);

            if (result == null)
            {
                return new ErrorDataResult<IQueryable<CarDetailDto>>(Messages.CarNotFound);
            }

            return new SuccessDataResult<IQueryable<CarDetailDto>>(result, Messages.CarsListed);
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

        //Check if plate exists
        private async Task<IResult> CheckIfPlateExist(string plate)
        {
            var trimmedName = plate.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(trimmedName))
            {
                return new ErrorResult(Messages.CarInvalid);
            }

            var existingPlate = await _carDal.GetSingleAsync(p => p.Plate.Trim().ToLower() == trimmedName);

            if (existingPlate != null)
            {
                return new ErrorResult(Messages.CarAlreadyExists);
            }

            return null;
        }


    }
}
