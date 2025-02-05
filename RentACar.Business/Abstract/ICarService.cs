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

        // DTO's methods
        Task<CarDetailDto> GetCarDetailsByIdAsync(int id);
        Task<List<CarDetailDto>> GetCarsDetailsAsync();
        Task<List<CarDetailDto>> GetCarsByBrandAsync(string brandName);
        Task<List<CarDetailDto>> GetCarsByColorAsync(string colorName);
        Task<List<CarDetailDto>> GetCarsByPriceRangeAsync(decimal minPrice, decimal maxPrice);
        Task<List<CarDetailDto>> GetCarsByAvailabilityAsync(CarStatus status);
        Task<List<CarDetailDto>> GetCarsByModelYearAsync(int year);
        Task<List<CarDetailDto>> GetCarsByFuelTypeAsync(string fuelType);
        Task<List<CarDetailDto>> GetCarsByTransmissionTypeAsync(string transmissionType);
        Task<List<CarDetailDto>> GetCarsByModelYearRangeAsync(int minYear, int maxYear);
        Task<List<CarDetailDto>> GetCarsByMileageRangeAsync(int minMileage, int maxMileage);


        Task<IDataResult<IEnumerable<Car>>> GetCarsAsync();
        Task<IDataResult<Car>> GetSingleAsync(int id);
        Task<IResult> AddAsync(Car car);
        Task<IResult> UpdateAsync(Car car);
        Task<IResult> DeleteAsync(Car car);

    }
}
