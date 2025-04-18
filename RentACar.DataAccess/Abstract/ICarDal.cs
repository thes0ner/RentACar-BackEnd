﻿using RentACar.Core.DataAccess.Repositories.EntityFrameworkRepository.Abstract;
using RentACar.Entities.Enums;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using RentACar.Entities.DTO;

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
