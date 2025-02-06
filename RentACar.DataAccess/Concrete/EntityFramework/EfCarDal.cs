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

namespace RentACar.DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarDbContext>, ICarDal
    {

        public async Task<List<CarDetailDto>> GetCarsDetailsAsync()
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

        public async Task<List<CarDetailDto>> GetCarsByBrandAsync(string brandName)
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

        public async Task<List<CarDetailDto>> GetCarsByColorAsync(string colorName)
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

        public async Task<List<CarDetailDto>> GetCarsByPriceRangeAsync(decimal minPrice, decimal maxPrice)
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

        public async Task<List<CarDetailDto>> GetCarsByAvailabilityAsync(CarStatus status)
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

        public async Task<List<CarDetailDto>> GetCarsByModelYearAsync(int year)
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

        public async Task<List<CarDetailDto>> GetCarsByFuelTypeAsync(string fuelType)
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

        public async Task<List<CarDetailDto>> GetCarsByTransmissionTypeAsync(string transmissionType)
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

        public async Task<List<CarDetailDto>> GetCarsByModelYearRangeAsync(int minYear, int maxYear)
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

        public async Task<List<CarDetailDto>> GetCarsByMileageRangeAsync(int minMileage, int maxMileage)
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


    }
}

