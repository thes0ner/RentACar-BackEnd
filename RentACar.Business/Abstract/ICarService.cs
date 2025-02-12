using RentACar.Core.Entities.Concrete;
using RentACar.Core.Entities.DTO_s;
using RentACar.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Abstract
{
    public interface ICarService
    {

        // Commands
        Task<IResult> AddAsync(Car car);
        Task<IResult> UpdateAsync(Car car);
        Task<IResult> DeleteAsync(Car car);

        // Queries
        IDataResult<IQueryable<Car>> GetAllCars();

        Task<IDataResult<Car>> GetSingleAsync(int id);
        Task<IDataResult<CarDetailDto>> GetCarDetailsByIdAsync(int id);
        Task<IDataResult<IEnumerable<CarDetailDto>>> GetCarsDetailsAsync();
        Task<IDataResult<IEnumerable<CarDetailDto>>> GetCarsByBrandAsync(string brandName);
        Task<IDataResult<IEnumerable<CarDetailDto>>> GetCarsByColorAsync(string colorName);
        Task<IDataResult<IEnumerable<CarDetailDto>>> GetCarsByPriceRangeAsync(decimal minPrice, decimal maxPrice);
        Task<IDataResult<IEnumerable<CarDetailDto>>> GetCarsByAvailabilityAsync(CarStatus status);
        Task<IDataResult<IEnumerable<CarDetailDto>>> GetCarsByModelYearAsync(int year);
        Task<IDataResult<IEnumerable<CarDetailDto>>> GetCarsByFuelTypeAsync(string fuelType);
        Task<IDataResult<IEnumerable<CarDetailDto>>> GetCarsByTransmissionTypeAsync(string transmissionType);
        Task<IDataResult<IEnumerable<CarDetailDto>>> GetCarsByModelYearRangeAsync(int minYear, int maxYear);
        Task<IDataResult<IEnumerable<CarDetailDto>>> GetCarsByMileageRangeAsync(int minMileage, int maxMileage);
        Task<IDataResult<Dictionary<object, IEnumerable<CarDetailDto>>>> GetCarsGroupByBrandAsync(string brandName);
        Task<IDataResult<Dictionary<object, IEnumerable<CarDetailDto>>>> GetCarsGroupByColorAsync(string colorName);
        Task<IDataResult<Dictionary<object, IEnumerable<CarDetailDto>>>> GetCarsGroupByFuleTypeAsync(string fuelType);
        Task<IDataResult<Dictionary<object, IEnumerable<CarDetailDto>>>> GetCarsGroupByTransmissionTypeAsync(string transmissionType);
        Task<IDataResult<Dictionary<object, IEnumerable<CarDetailDto>>>> GetCarsGroupByVehicleTypeAsync(string vehicleType);
        Task<IDataResult<Dictionary<object, IEnumerable<CarDetailDto>>>> GetCarsGroupByDailyPriceAsync(decimal dailyPrice);
        Task<IDataResult<Dictionary<object, IEnumerable<CarDetailDto>>>> GetCarsGroupByModelAsync(string model);
        Task<IDataResult<Dictionary<object, IEnumerable<CarDetailDto>>>> GetCarsGroupByYearAsync(int year);
        Task<IDataResult<Dictionary<object, IEnumerable<CarDetailDto>>>> GetCarsGroupByAvailabilityAsync(CarStatus status);









    }
}
