using RentACar.Core.DataAccess.Repositories.EntityFrameworkRepository.Abstract;
using RentACar.Core.Entities.Concrete;
using RentACar.Core.Entities.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {

        Task<List<CarDetailDto>> GetCarsDetailsAsync();
        Task<CarDetailDto> GetCarDetailsByIdAsync(int id);
        Task<List<CarDetailDto>> GetCarsByBrandAsync(string brandName);
        Task<List<CarDetailDto>> GetCarsByColorAsync(string colorName);
        Task<List<CarDetailDto>> GetCarsByPriceRangeAsync(decimal minPrice, decimal maxPrice);
        Task<List<CarDetailDto>> GetCarsByAvailabilityAsync(CarStatus status);
        Task<List<CarDetailDto>> GetCarsByModelYearAsync(int year);
        Task<List<CarDetailDto>> GetCarsByFuelTypeAsync(string fuelType);
        Task<List<CarDetailDto>> GetCarsByTransmissionTypeAsync(string transmissionType);
        Task<List<CarDetailDto>> GetCarsByModelYearRangeAsync(int minYear, int maxYear);
        Task<List<CarDetailDto>> GetCarsByMileageRangeAsync(int minMileage, int maxMileage);

    }
}
