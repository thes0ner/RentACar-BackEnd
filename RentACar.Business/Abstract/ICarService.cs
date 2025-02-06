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


        Task<IDataResult<IEnumerable<Car>>> GetCarsAsync();

        //Task<IDataResult<IEnumerable<Car>>> GetCarsBrandsAsync();

        Task<IDataResult<Car>> GetSingleAsync(int id);
        Task<IResult> AddAsync(Car car);
        Task<IResult> UpdateAsync(Car car);
        Task<IResult> DeleteAsync(Car car);

    }
}
