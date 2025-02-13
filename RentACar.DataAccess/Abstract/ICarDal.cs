using RentACar.Core.DataAccess.Repositories.EntityFrameworkRepository.Abstract;
using RentACar.Core.Entities.Concrete;
using RentACar.Core.Entities.DTO_s;
using RentACar.Core.Entities.Enums;
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



        Task<CarDetailDto> GetCarDetailById(int id);
        IQueryable<CarDetailDto> GetCarDetails();
        IQueryable<CarDetailDto> GetCarsByBrandName(string brandName);
        IQueryable<CarDetailDto> GetCarsByColorName(string colorName);
        IQueryable<CarDetailDto> GetCarsByModelYear(int year);
        IQueryable<CarDetailDto> GetCarsByFuelType(string fuelType);
        IQueryable<CarDetailDto> GetCarsByTransmissionType(string transmissionType);
        IQueryable<CarDetailDto> GetCarsByAvailability(CarStatus status);
        IQueryable<CarDetailDto> GetCarsByPriceRange(decimal minPrice, decimal maxPrice);
        IQueryable<CarDetailDto> GetCarsByModelYearRange(int minYear, int maxYear);
        IQueryable<CarDetailDto> GetCarsByMileageRange(int minMileage, int maxMileage);
        Dictionary<object, IQueryable<CarDetailDto>> GetGroupedCars(Func<CarDetailDto, object> groupBy, Expression<Func<CarDetailDto, bool>> filter = null);





    }
}
