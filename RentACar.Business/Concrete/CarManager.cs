using RentACar.Business.Abstract;
using RentACar.DataAccess.Abstract;
using RentACar.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Core.Entities.DTO_s;

namespace RentACar.Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
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

        public async Task<IEnumerable<Car>> GetCarsAsync()
        {
            return await _carDal.GetAllAsync();
        }

        public async Task<Car> GetSingleAsync(int id)
        {
            return await _carDal.GetSingleAsync(c => c.Id == id);
        }

        public async Task AddAsync(Car car)
        {
            await _carDal.AddAsync(car);
        }

        public async Task UpdateAsync(Car car)
        {
            var updatedCar = _carDal.GetSingleAsync(c => c.Id == car.Id);

            if (updatedCar != null)
            {
                updatedCar.Result.BrandId = car.BrandId;
                updatedCar.Result.ColorId = car.ColorId;
                updatedCar.Result.Model = car.Model;
                updatedCar.Result.Year = car.Year;
                updatedCar.Result.DailyPrice = car.DailyPrice;
                updatedCar.Result.Description = car.Description;
                updatedCar.Result.FuelType = car.FuelType;
                updatedCar.Result.TransmissionType = car.TransmissionType;
                updatedCar.Result.Mileage = car.Mileage;
                updatedCar.Result.Status = car.Status;
                await _carDal.UpdateAsync(updatedCar.Result);
            }
        }

        public async Task DeleteAsync(Car car)
        {
           await _carDal.DeleteAsync(car);
        }
    }
}
