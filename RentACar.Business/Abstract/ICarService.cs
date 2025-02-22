using RentACar.Entities.Concrete;
using RentACar.Core.Entities.DTO_s;
using RentACar.Entities.Enums;
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
        Task<IDataResult<CarDetailDto>> GetCarDetailById(int id);
        IDataResult<IQueryable<CarDetailDto>> GetCarDetails();
        IDataResult<IQueryable<CarDetailDto>> GetCarsByBrandName(string brandName);
        IDataResult<IQueryable<CarDetailDto>> GetCarsByColorName(string colorName);
        IDataResult<IQueryable<CarDetailDto>> GetCarsByModelYear(int year);
        IDataResult<IQueryable<CarDetailDto>> GetCarsByFuelType(string fuelType);
        IDataResult<IQueryable<CarDetailDto>> GetCarsByTransmissionType(string transmissionType);
        IDataResult<IQueryable<CarDetailDto>> GetCarsByAvailability(CarStatus status);
        IDataResult<IQueryable<CarDetailDto>> GetCarsByPriceRange(decimal minPrice, decimal maxPrice);
        IDataResult<IQueryable<CarDetailDto>> GetCarsByModelYearRange(int minYear, int maxYear);
        IDataResult<IQueryable<CarDetailDto>> GetCarsByMileageRange(int minMileage, int maxMileage);

        // Grouped queries
        IDataResult<Dictionary<object, IQueryable<CarDetailDto>>> GetCarsGroupByBrand(string brandName);
        IDataResult<Dictionary<object, IQueryable<CarDetailDto>>> GetCarsGroupByColor(string colorName);
        IDataResult<Dictionary<object, IQueryable<CarDetailDto>>> GetCarsGroupByFuel(string fuel);
        IDataResult<Dictionary<object, IQueryable<CarDetailDto>>> GetCarsGroupByTransmission(string transmission);
        IDataResult<Dictionary<object, IQueryable<CarDetailDto>>> GetCarsGroupByVehicle(string vehicle);
        IDataResult<Dictionary<object, IQueryable<CarDetailDto>>> GetCarsGroupByDailyPrice(decimal dailyPrice);
        IDataResult<Dictionary<object, IQueryable<CarDetailDto>>> GetCarsGroupByModel(string model);
        IDataResult<Dictionary<object, IQueryable<CarDetailDto>>> GetCarsGroupByYear(int year);
        IDataResult<Dictionary<object, IQueryable<CarDetailDto>>> GetCarsGroupByAvailability(CarStatus status);









    }
}
