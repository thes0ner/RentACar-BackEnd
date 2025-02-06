using RentACar.Core.DataAccess.Repositories.EntityFrameworkRepository.Abstract;
using RentACar.DataAccess.Abstract;
using RentACar.DataAccess.Concrete.EntityFramework.DatabaseContext;
using RentACar.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RentACar.Core.Entities.DTO_s;
using Microsoft.VisualBasic.FileIO;
using System.Linq.Expressions;

namespace RentACar.DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarDbContext>, ICarDal
    {

        public async Task<CarDetailDto> GetCarDetailsByIdAsync(int id)
        {
            using (var context = new RentACarDbContext())
            {
                var result = await (from car in context.Cars
                                    join brand in context.Brands on car.BrandId equals brand.Id
                                    join color in context.Colors on car.ColorId equals color.Id
                                    join fuel in context.FuelTypes on car.FuelId equals fuel.Id
                                    join transmission in context.TransmissionTypes on car.TransmissionId equals transmission.Id
                                    join vehicle in context.VehicleTypes on car.VehicleId equals vehicle.Id
                                    join location in context.Locations on car.LocationId equals location.Id
                                    where car.Id == id
                                    select new CarDetailDto
                                    {
                                        Id = car.Id,
                                        BrandName = brand.Name,
                                        ColorName = color.Name,
                                        FuelType = fuel.Type,
                                        TransmissionType = transmission.Type,
                                        VehicleType = vehicle.Type,
                                        LocationCountry = location.Country,
                                        LocationCity = location.City,
                                        LocationAddress = location.Address,
                                        DailyPrice = car.DailyPrice,
                                        Model = car.Model,
                                        Year = car.Year,
                                        Mileage = car.Mileage,
                                        Description = car.Description,
                                        Status = car.Status
                                    }).FirstOrDefaultAsync();
                return result;

            }
        }

        public async Task<IEnumerable<CarDetailDto>> GetCarsDetailsAsync()
        {
            using (var context = new RentACarDbContext())
            {
                var result = await (from car in context.Cars
                                    join brand in context.Brands on car.BrandId equals brand.Id
                                    join color in context.Colors on car.ColorId equals color.Id
                                    join fuel in context.FuelTypes on car.FuelId equals fuel.Id
                                    join transmission in context.TransmissionTypes on car.TransmissionId equals transmission.Id
                                    join vehicle in context.VehicleTypes on car.VehicleId equals vehicle.Id
                                    join location in context.Locations on car.LocationId equals location.Id
                                    select new CarDetailDto
                                    {
                                        Id = car.Id,
                                        BrandName = brand.Name,
                                        ColorName = color.Name,
                                        FuelType = fuel.Type,
                                        TransmissionType = transmission.Type,
                                        VehicleType = vehicle.Type,
                                        LocationCountry = location.Country,
                                        LocationCity = location.City,
                                        LocationAddress = location.Address,
                                        DailyPrice = car.DailyPrice,
                                        Model = car.Model,
                                        Year = car.Year,
                                        Mileage = car.Mileage,
                                        Description = car.Description,
                                        Status = car.Status

                                    }).ToListAsync();

                return result.ToList();

            }

        }

        public async Task<IEnumerable<CarDetailDto>> GetCarsByBrandAsync(string brandName)
        {
            using (var context = new RentACarDbContext())
            {
                var result = await (from car in context.Cars
                                    where car.Brand.Name == brandName
                                    join brand in context.Brands on car.BrandId equals brand.Id
                                    join color in context.Colors on car.ColorId equals color.Id
                                    join fuel in context.FuelTypes on car.FuelId equals fuel.Id
                                    join transmission in context.TransmissionTypes on car.TransmissionId equals transmission.Id
                                    join vehicle in context.VehicleTypes on car.VehicleId equals vehicle.Id
                                    join location in context.Locations on car.LocationId equals location.Id
                                    select new CarDetailDto
                                    {
                                        Id = car.Id,
                                        BrandName = brand.Name,
                                        ColorName = color.Name,
                                        FuelType = fuel.Type,
                                        TransmissionType = transmission.Type,
                                        VehicleType = vehicle.Type,
                                        LocationCountry = location.Country,
                                        LocationCity = location.City,
                                        LocationAddress = location.Address,
                                        DailyPrice = car.DailyPrice,
                                        Model = car.Model,
                                        Year = car.Year,
                                        Mileage = car.Mileage,
                                        Description = car.Description,
                                        Status = car.Status
                                    }).ToListAsync();

                return result;
            }

        }

        public async Task<IEnumerable<CarDetailDto>> GetCarsByColorAsync(string colorName)
        {
            using (var context = new RentACarDbContext())
            {
                var result = await (from car in context.Cars
                                    where car.Color.Name == colorName
                                    join brand in context.Brands on car.BrandId equals brand.Id
                                    join color in context.Colors on car.ColorId equals color.Id
                                    join fuel in context.FuelTypes on car.FuelId equals fuel.Id
                                    join transmission in context.TransmissionTypes on car.TransmissionId equals transmission.Id
                                    join vehicle in context.VehicleTypes on car.VehicleId equals vehicle.Id
                                    join location in context.Locations on car.LocationId equals location.Id
                                    select new CarDetailDto
                                    {
                                        Id = car.Id,
                                        BrandName = brand.Name,
                                        ColorName = color.Name,
                                        FuelType = fuel.Type,
                                        TransmissionType = transmission.Type,
                                        VehicleType = vehicle.Type,
                                        LocationCountry = location.Country,
                                        LocationCity = location.City,
                                        LocationAddress = location.Address,
                                        DailyPrice = car.DailyPrice,
                                        Model = car.Model,
                                        Year = car.Year,
                                        Mileage = car.Mileage,
                                        Description = car.Description,
                                        Status = car.Status
                                    }).ToListAsync();

                return result;

            }

        }

        public async Task<IEnumerable<CarDetailDto>> GetCarsByPriceRangeAsync(decimal minPrice, decimal maxPrice)
        {
            using (var context = new RentACarDbContext())
            {
                var result = await (from car in context.Cars
                                    where car.DailyPrice >= minPrice && car.DailyPrice <= maxPrice
                                    join brand in context.Brands on car.BrandId equals brand.Id
                                    join color in context.Colors on car.ColorId equals color.Id
                                    join fuel in context.FuelTypes on car.FuelId equals fuel.Id
                                    join transmission in context.TransmissionTypes on car.TransmissionId equals transmission.Id
                                    join vehicle in context.VehicleTypes on car.VehicleId equals vehicle.Id
                                    join location in context.Locations on car.LocationId equals location.Id
                                    select new CarDetailDto
                                    {
                                        Id = car.Id,
                                        BrandName = brand.Name,
                                        ColorName = color.Name,
                                        FuelType = fuel.Type,
                                        TransmissionType = transmission.Type,
                                        VehicleType = vehicle.Type,
                                        LocationCountry = location.Country,
                                        LocationCity = location.City,
                                        LocationAddress = location.Address,
                                        DailyPrice = car.DailyPrice,
                                        Model = car.Model,
                                        Year = car.Year,
                                        Mileage = car.Mileage,
                                        Description = car.Description,
                                        Status = car.Status
                                    }).ToListAsync();

                return result;
            }
        }

        public async Task<IEnumerable<CarDetailDto>> GetCarsByAvailabilityAsync(CarStatus status)
        {
            using (var context = new RentACarDbContext())
            {
                var result = await (from car in context.Cars
                                    where car.Status == status // Filter by CarStatus
                                    join brand in context.Brands on car.BrandId equals brand.Id
                                    join color in context.Colors on car.ColorId equals color.Id
                                    join fuel in context.FuelTypes on car.FuelId equals fuel.Id
                                    join transmission in context.TransmissionTypes on car.TransmissionId equals transmission.Id
                                    join vehicle in context.VehicleTypes on car.VehicleId equals vehicle.Id
                                    join location in context.Locations on car.LocationId equals location.Id
                                    select new CarDetailDto
                                    {
                                        Id = car.Id,
                                        BrandName = brand.Name,
                                        ColorName = color.Name,
                                        FuelType = fuel.Type,
                                        TransmissionType = transmission.Type,
                                        VehicleType = vehicle.Type,
                                        LocationAddress = location.Address,
                                        LocationCity = location.City,
                                        LocationCountry = location.Country,
                                        DailyPrice = car.DailyPrice,
                                        Model = car.Model,
                                        Year = car.Year,
                                        Mileage = car.Mileage,
                                        Description = car.Description,
                                        Status = car.Status,
                                        CreatedDate = car.CreatedDate,
                                        UpdatedDate = car.UpdatedDate
                                    }).ToListAsync();

                return result;
            }
        }

        public async Task<IEnumerable<CarDetailDto>> GetCarsByModelYearAsync(int year)
        {
            using (var context = new RentACarDbContext())
            {
                var result = await (from car in context.Cars
                                    where car.Year == year
                                    join brand in context.Brands on car.BrandId equals brand.Id
                                    join color in context.Colors on car.ColorId equals color.Id
                                    join fuel in context.FuelTypes on car.FuelId equals fuel.Id
                                    join transmission in context.TransmissionTypes on car.TransmissionId equals transmission.Id
                                    join vehicle in context.VehicleTypes on car.VehicleId equals vehicle.Id
                                    join location in context.Locations on car.LocationId equals location.Id
                                    select new CarDetailDto
                                    {
                                        Id = car.Id,
                                        BrandName = brand.Name,
                                        ColorName = color.Name,
                                        FuelType = fuel.Type,
                                        TransmissionType = transmission.Type,
                                        VehicleType = vehicle.Type,
                                        LocationAddress = location.Address,
                                        LocationCity = location.City,
                                        LocationCountry = location.Country,
                                        DailyPrice = car.DailyPrice,
                                        Model = car.Model,
                                        Year = car.Year,
                                        Mileage = car.Mileage,
                                        Description = car.Description,
                                        Status = car.Status,
                                        CreatedDate = car.CreatedDate,
                                        UpdatedDate = car.UpdatedDate
                                    }).ToListAsync();

                return result;
            }
        }

        public async Task<IEnumerable<CarDetailDto>> GetCarsByFuelTypeAsync(string fuelType)
        {
            using (var context = new RentACarDbContext())
            {
                var result = await (from car in context.Cars
                                    where car.FuelType.Type == fuelType
                                    join brand in context.Brands on car.BrandId equals brand.Id
                                    join color in context.Colors on car.ColorId equals color.Id
                                    join fuel in context.FuelTypes on car.FuelId equals fuel.Id
                                    join transmission in context.TransmissionTypes on car.TransmissionId equals transmission.Id
                                    join vehicle in context.VehicleTypes on car.VehicleId equals vehicle.Id
                                    join location in context.Locations on car.LocationId equals location.Id
                                    select new CarDetailDto
                                    {
                                        Id = car.Id,
                                        BrandName = brand.Name,
                                        ColorName = color.Name,
                                        FuelType = fuel.Type,
                                        TransmissionType = transmission.Type,
                                        VehicleType = vehicle.Type,
                                        LocationAddress = location.Address,
                                        LocationCity = location.City,
                                        LocationCountry = location.Country,
                                        DailyPrice = car.DailyPrice,
                                        Model = car.Model,
                                        Year = car.Year,
                                        Mileage = car.Mileage,
                                        Description = car.Description,
                                        Status = car.Status,
                                        CreatedDate = car.CreatedDate,
                                        UpdatedDate = car.UpdatedDate
                                    }).ToListAsync();

                return result;
            }
        }

        public async Task<IEnumerable<CarDetailDto>> GetCarsByTransmissionTypeAsync(string transmissionType)
        {
            using (var context = new RentACarDbContext())
            {
                var result = await (from car in context.Cars
                                    where car.TransmissionType.Type == transmissionType
                                    join brand in context.Brands on car.BrandId equals brand.Id
                                    join color in context.Colors on car.ColorId equals color.Id
                                    join fuel in context.FuelTypes on car.FuelId equals fuel.Id
                                    join transmission in context.TransmissionTypes on car.TransmissionId equals transmission.Id
                                    join vehicle in context.VehicleTypes on car.VehicleId equals vehicle.Id
                                    join location in context.Locations on car.LocationId equals location.Id
                                    select new CarDetailDto
                                    {
                                        Id = car.Id,
                                        BrandName = brand.Name,
                                        ColorName = color.Name,
                                        FuelType = fuel.Type,
                                        TransmissionType = transmission.Type,
                                        VehicleType = vehicle.Type,
                                        LocationAddress = location.Address,
                                        LocationCity = location.City,
                                        LocationCountry = location.Country,
                                        DailyPrice = car.DailyPrice,
                                        Model = car.Model,
                                        Year = car.Year,
                                        Mileage = car.Mileage,
                                        Description = car.Description,
                                        Status = car.Status,
                                        CreatedDate = car.CreatedDate,
                                        UpdatedDate = car.UpdatedDate
                                    }).ToListAsync();

                return result;
            }
        }

        public async Task<IEnumerable<CarDetailDto>> GetCarsByModelYearRangeAsync(int minYear, int maxYear)
        {
            using (var context = new RentACarDbContext())
            {
                var result = await (from car in context.Cars
                                    where car.Year >= minYear && car.Year <= maxYear
                                    join brand in context.Brands on car.BrandId equals brand.Id
                                    join color in context.Colors on car.ColorId equals color.Id
                                    join fuel in context.FuelTypes on car.FuelId equals fuel.Id
                                    join transmission in context.TransmissionTypes on car.TransmissionId equals transmission.Id
                                    join vehicle in context.VehicleTypes on car.VehicleId equals vehicle.Id
                                    join location in context.Locations on car.LocationId equals location.Id
                                    select new CarDetailDto
                                    {
                                        Id = car.Id,
                                        BrandName = brand.Name,
                                        ColorName = color.Name,
                                        FuelType = fuel.Type,
                                        TransmissionType = transmission.Type,
                                        VehicleType = vehicle.Type,
                                        LocationAddress = location.Address,
                                        LocationCity = location.City,
                                        LocationCountry = location.Country,
                                        DailyPrice = car.DailyPrice,
                                        Model = car.Model,
                                        Year = car.Year,
                                        Mileage = car.Mileage,
                                        Description = car.Description,
                                        Status = car.Status,
                                        CreatedDate = car.CreatedDate,
                                        UpdatedDate = car.UpdatedDate
                                    }).ToListAsync();

                return result;
            }
        }

        public async Task<IEnumerable<CarDetailDto>> GetCarsByMileageRangeAsync(int minMileage, int maxMileage)
        {
            using (var context = new RentACarDbContext())
            {
                var result = await (from car in context.Cars
                                    where car.Mileage >= minMileage && car.Mileage <= maxMileage
                                    join brand in context.Brands on car.BrandId equals brand.Id
                                    join color in context.Colors on car.ColorId equals color.Id
                                    join fuel in context.FuelTypes on car.FuelId equals fuel.Id
                                    join transmission in context.TransmissionTypes on car.TransmissionId equals transmission.Id
                                    join vehicle in context.VehicleTypes on car.VehicleId equals vehicle.Id
                                    join location in context.Locations on car.LocationId equals location.Id
                                    select new CarDetailDto
                                    {
                                        Id = car.Id,
                                        BrandName = brand.Name,
                                        ColorName = color.Name,
                                        FuelType = fuel.Type,
                                        TransmissionType = transmission.Type,
                                        VehicleType = vehicle.Type,
                                        LocationAddress = location.Address,
                                        LocationCity = location.City,
                                        LocationCountry = location.Country,
                                        DailyPrice = car.DailyPrice,
                                        Model = car.Model,
                                        Year = car.Year,
                                        Mileage = car.Mileage,
                                        Description = car.Description,
                                        Status = car.Status,
                                        CreatedDate = car.CreatedDate,
                                        UpdatedDate = car.UpdatedDate
                                    }).ToListAsync();

                return result;
            }
        }

        public async Task<Dictionary<object, IEnumerable<CarDetailDto>>> GetCarsGroupedAsync(Func<CarDetailDto, object> groupBy, Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (var context = new RentACarDbContext())
            {
                var query = context.Cars
                    .Select(c => new CarDetailDto
                    {
                        Id = c.Id,
                        BrandName = c.Brand.Name,
                        ColorName = c.Color.Name,
                        Model = c.Model,
                        Year = c.Year,
                        DailyPrice = c.DailyPrice,
                        FuelType = c.FuelType.Type,
                        TransmissionType = c.TransmissionType.Type,
                        VehicleType = c.VehicleType.Type,
                        Description = c.Description,
                        LocationAddress = c.Location.Address,
                        LocationCity = c.Location.City,
                        LocationCountry = c.Location.Country,
                        Mileage = c.Mileage,
                        Status = c.Status,
                    });

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                var cars = await query.ToListAsync();

                if (cars == null || !cars.Any())
                {
                    return new Dictionary<object, IEnumerable<CarDetailDto>>();
                }

                return cars
                    .GroupBy(groupBy)
                        .ToDictionary(g => g.Key, g => g.AsEnumerable());
            }
        }
    }
}

