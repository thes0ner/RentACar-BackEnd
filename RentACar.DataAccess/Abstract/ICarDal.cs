using RentACar.Core.DataAccess.Repositories.EntityFrameworkRepository.Abstract;
using RentACar.Core.Entities.Concrete;
using RentACar.Core.Entities.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {

        //Task<int> GetTotalCarsAsync();
        //Task<int> GetTotalCarsByStatusAsync(CarStatus status);
        //Task<decimal> GetAverageDailyPriceAsync();
        //Task<Dictionary<int, int>> GetMostRentedCarsAsync(int topRented);

        Task<CarDetailDto> GetCarDetailsByIdAsync(int id);
        Task<IEnumerable<CarDetailDto>> GetCarsDetailsAsync();

        // Filtering Methods
        Task<IEnumerable<CarDetailDto>> GetCarsByBrandAsync(string brandName);
        Task<IEnumerable<CarDetailDto>> GetCarsByColorAsync(string colorName);
        Task<IEnumerable<CarDetailDto>> GetCarsByPriceRangeAsync(decimal minPrice, decimal maxPrice);
        Task<IEnumerable<CarDetailDto>> GetCarsByAvailabilityAsync(CarStatus status);
        Task<IEnumerable<CarDetailDto>> GetCarsByModelYearAsync(int year);
        Task<IEnumerable<CarDetailDto>> GetCarsByFuelTypeAsync(string fuelType);
        Task<IEnumerable<CarDetailDto>> GetCarsByTransmissionTypeAsync(string transmissionType);
        Task<IEnumerable<CarDetailDto>> GetCarsByModelYearRangeAsync(int minYear, int maxYear);
        Task<IEnumerable<CarDetailDto>> GetCarsByMileageRangeAsync(int minMileage, int maxMileage);

        // Dinamically grouping.
        Task<Dictionary<object, IEnumerable<CarDetailDto>>> GetCarsGroupedAsync(Func<CarDetailDto, object> groupBy, Expression<Func<CarDetailDto, bool>> filter = null);





    }
}
