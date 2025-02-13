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
using RentACar.Core.Entities.Enums;

namespace RentACar.DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, RentACarDbContext>, ICarDal
    {
        public EfCarDal(RentACarDbContext context) : base(context)
        {

        }

        public async Task<CarDetailDto> GetCarDetailById(int id)
        {

            var result = await (from car in _context.Cars
                                join brand in _context.Brands on car.BrandId equals brand.Id
                                join color in _context.Colors on car.ColorId equals color.Id
                                join fuel in _context.Fuels on car.FuelId equals fuel.Id
                                join transmission in _context.Transmissions on car.TransmissionId equals transmission.Id
                                join vehicle in _context.Vehicles on car.VehicleId equals vehicle.Id
                                join location in _context.Locations on car.LocationId equals location.Id
                                where car.Id == id
                                select new CarDetailDto
                                {
                                    Id = car.Id,
                                    BrandName = brand.Name,
                                    ColorName = color.Name,
                                    Fuel = fuel.Type,
                                    Transmission = transmission.Type,
                                    Vehicle = vehicle.Type,
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

        public IQueryable<CarDetailDto> GetCarDetails()
        {

            var result = (from car in _context.Cars
                          join brand in _context.Brands on car.BrandId equals brand.Id
                          join color in _context.Colors on car.ColorId equals color.Id
                          join fuel in _context.Fuels on car.FuelId equals fuel.Id
                          join transmission in _context.Transmissions on car.TransmissionId equals transmission.Id
                          join vehicle in _context.Vehicles on car.VehicleId equals vehicle.Id
                          join location in _context.Locations on car.LocationId equals location.Id
                          select new CarDetailDto
                          {
                              Id = car.Id,
                              BrandName = brand.Name,
                              ColorName = color.Name,
                              Fuel = fuel.Type,
                              Transmission = transmission.Type,
                              Vehicle = vehicle.Type,
                              LocationCountry = location.Country,
                              LocationCity = location.City,
                              LocationAddress = location.Address,
                              DailyPrice = car.DailyPrice,
                              Model = car.Model,
                              Year = car.Year,
                              Mileage = car.Mileage,
                              Description = car.Description,
                              Status = car.Status

                          }).AsQueryable();

            return result;


        }

        public IQueryable<CarDetailDto> GetCarsByBrandName(string brandName)
        {
            var result = (from car in _context.Cars
                          where car.Brand.Name == brandName
                          join brand in _context.Brands on car.BrandId equals brand.Id
                          join color in _context.Colors on car.ColorId equals color.Id
                          join fuel in _context.Fuels on car.FuelId equals fuel.Id
                          join transmission in _context.Transmissions on car.TransmissionId equals transmission.Id
                          join vehicle in _context.Vehicles on car.VehicleId equals vehicle.Id
                          join location in _context.Locations on car.LocationId equals location.Id
                          select new CarDetailDto
                          {
                              Id = car.Id,
                              BrandName = brand.Name,
                              ColorName = color.Name,
                              Fuel = fuel.Type,
                              Transmission = transmission.Type,
                              Vehicle = vehicle.Type,
                              LocationCountry = location.Country,
                              LocationCity = location.City,
                              LocationAddress = location.Address,
                              DailyPrice = car.DailyPrice,
                              Model = car.Model,
                              Year = car.Year,
                              Mileage = car.Mileage,
                              Description = car.Description,
                              Status = car.Status
                          }).AsQueryable();

            return result;

        }

        public IQueryable<CarDetailDto> GetCarsByColorName(string colorName)
        {

            var result = (from car in _context.Cars
                          where car.Color.Name == colorName
                          join brand in _context.Brands on car.BrandId equals brand.Id
                          join color in _context.Colors on car.ColorId equals color.Id
                          join fuel in _context.Fuels on car.FuelId equals fuel.Id
                          join transmission in _context.Transmissions on car.TransmissionId equals transmission.Id
                          join vehicle in _context.Vehicles on car.VehicleId equals vehicle.Id
                          join location in _context.Locations on car.LocationId equals location.Id
                          select new CarDetailDto
                          {
                              Id = car.Id,
                              BrandName = brand.Name,
                              ColorName = color.Name,
                              Fuel = fuel.Type,
                              Transmission = transmission.Type,
                              Vehicle = vehicle.Type,
                              LocationCountry = location.Country,
                              LocationCity = location.City,
                              LocationAddress = location.Address,
                              DailyPrice = car.DailyPrice,
                              Model = car.Model,
                              Year = car.Year,
                              Mileage = car.Mileage,
                              Description = car.Description,
                              Status = car.Status
                          }).AsQueryable();

            return result;

        }

        public IQueryable<CarDetailDto> GetCarsByPriceRange(decimal minPrice, decimal maxPrice)
        {

            var result = (from car in _context.Cars
                          where car.DailyPrice >= minPrice && car.DailyPrice <= maxPrice
                          join brand in _context.Brands on car.BrandId equals brand.Id
                          join color in _context.Colors on car.ColorId equals color.Id
                          join fuel in _context.Fuels on car.FuelId equals fuel.Id
                          join transmission in _context.Transmissions on car.TransmissionId equals transmission.Id
                          join vehicle in _context.Vehicles on car.VehicleId equals vehicle.Id
                          join location in _context.Locations on car.LocationId equals location.Id
                          select new CarDetailDto
                          {
                              Id = car.Id,
                              BrandName = brand.Name,
                              ColorName = color.Name,
                              Fuel = fuel.Type,
                              Transmission = transmission.Type,
                              Vehicle = vehicle.Type,
                              LocationCountry = location.Country,
                              LocationCity = location.City,
                              LocationAddress = location.Address,
                              DailyPrice = car.DailyPrice,
                              Model = car.Model,
                              Year = car.Year,
                              Mileage = car.Mileage,
                              Description = car.Description,
                              Status = car.Status
                          }).AsQueryable();

            return result;

        }

        public IQueryable<CarDetailDto> GetCarsByAvailability(CarStatus status)
        {

            var result = (from car in _context.Cars
                          where car.Status == status
                          join brand in _context.Brands on car.BrandId equals brand.Id
                          join color in _context.Colors on car.ColorId equals color.Id
                          join fuel in _context.Fuels on car.FuelId equals fuel.Id
                          join transmission in _context.Transmissions on car.TransmissionId equals transmission.Id
                          join vehicle in _context.Vehicles on car.VehicleId equals vehicle.Id
                          join location in _context.Locations on car.LocationId equals location.Id
                          select new CarDetailDto
                          {
                              Id = car.Id,
                              BrandName = brand.Name,
                              ColorName = color.Name,
                              Fuel = fuel.Type,
                              Transmission = transmission.Type,
                              Vehicle = vehicle.Type,
                              LocationAddress = location.Address,
                              LocationCity = location.City,
                              LocationCountry = location.Country,
                              DailyPrice = car.DailyPrice,
                              Model = car.Model,
                              Year = car.Year,
                              Mileage = car.Mileage,
                              Description = car.Description,
                              Status = car.Status,
                          }).AsQueryable();

            return result;

        }

        public IQueryable<CarDetailDto> GetCarsByModelYear(int year)
        {

            var result = (from car in _context.Cars
                          where car.Year == year
                          join brand in _context.Brands on car.BrandId equals brand.Id
                          join color in _context.Colors on car.ColorId equals color.Id
                          join fuel in _context.Fuels on car.FuelId equals fuel.Id
                          join transmission in _context.Transmissions on car.TransmissionId equals transmission.Id
                          join vehicle in _context.Vehicles on car.VehicleId equals vehicle.Id
                          join location in _context.Locations on car.LocationId equals location.Id
                          select new CarDetailDto
                          {
                              Id = car.Id,
                              BrandName = brand.Name,
                              ColorName = color.Name,
                              Fuel = fuel.Type,
                              Transmission = transmission.Type,
                              Vehicle = vehicle.Type,
                              LocationAddress = location.Address,
                              LocationCity = location.City,
                              LocationCountry = location.Country,
                              DailyPrice = car.DailyPrice,
                              Model = car.Model,
                              Year = car.Year,
                              Mileage = car.Mileage,
                              Description = car.Description,
                              Status = car.Status,
                          }).AsQueryable();

            return result;
        }

        public IQueryable<CarDetailDto> GetCarsByFuelType(string fuelType)
        {

            var result = (from car in _context.Cars
                          where car.Fuel.Type == fuelType
                          join brand in _context.Brands on car.BrandId equals brand.Id
                          join color in _context.Colors on car.ColorId equals color.Id
                          join fuel in _context.Fuels on car.FuelId equals fuel.Id
                          join transmission in _context.Transmissions on car.TransmissionId equals transmission.Id
                          join vehicle in _context.Vehicles on car.VehicleId equals vehicle.Id
                          join location in _context.Locations on car.LocationId equals location.Id
                          select new CarDetailDto
                          {
                              Id = car.Id,
                              BrandName = brand.Name,
                              ColorName = color.Name,
                              Fuel = fuel.Type,
                              Transmission = transmission.Type,
                              Vehicle = vehicle.Type,
                              LocationAddress = location.Address,
                              LocationCity = location.City,
                              LocationCountry = location.Country,
                              DailyPrice = car.DailyPrice,
                              Model = car.Model,
                              Year = car.Year,
                              Mileage = car.Mileage,
                              Description = car.Description,
                              Status = car.Status,
                          }).AsQueryable();

            return result;
        }

        public IQueryable<CarDetailDto> GetCarsByTransmissionType(string transmissionType)
        {

            var result = (from car in _context.Cars
                          where car.Transmission.Type == transmissionType
                          join brand in _context.Brands on car.BrandId equals brand.Id
                          join color in _context.Colors on car.ColorId equals color.Id
                          join fuel in _context.Fuels on car.FuelId equals fuel.Id
                          join transmission in _context.Transmissions on car.TransmissionId equals transmission.Id
                          join vehicle in _context.Vehicles on car.VehicleId equals vehicle.Id
                          join location in _context.Locations on car.LocationId equals location.Id
                          select new CarDetailDto
                          {
                              Id = car.Id,
                              BrandName = brand.Name,
                              ColorName = color.Name,
                              Fuel = fuel.Type,
                              Transmission = transmission.Type,
                              Vehicle = vehicle.Type,
                              LocationAddress = location.Address,
                              LocationCity = location.City,
                              LocationCountry = location.Country,
                              DailyPrice = car.DailyPrice,
                              Model = car.Model,
                              Year = car.Year,
                              Mileage = car.Mileage,
                              Description = car.Description,
                              Status = car.Status,
                          }).AsQueryable();

            return result;
        }


        public IQueryable<CarDetailDto> GetCarsByModelYearRange(int minYear, int maxYear)
        {

            var result = (from car in _context.Cars
                          where car.Year >= minYear && car.Year <= maxYear
                          join brand in _context.Brands on car.BrandId equals brand.Id
                          join color in _context.Colors on car.ColorId equals color.Id
                          join fuel in _context.Fuels on car.FuelId equals fuel.Id
                          join transmission in _context.Transmissions on car.TransmissionId equals transmission.Id
                          join vehicle in _context.Vehicles on car.VehicleId equals vehicle.Id
                          join location in _context.Locations on car.LocationId equals location.Id
                          select new CarDetailDto
                          {
                              Id = car.Id,
                              BrandName = brand.Name,
                              ColorName = color.Name,
                              Fuel = fuel.Type,
                              Transmission = transmission.Type,
                              Vehicle = vehicle.Type,
                              LocationAddress = location.Address,
                              LocationCity = location.City,
                              LocationCountry = location.Country,
                              DailyPrice = car.DailyPrice,
                              Model = car.Model,
                              Year = car.Year,
                              Mileage = car.Mileage,
                              Description = car.Description,
                              Status = car.Status,
                          }).AsQueryable();

            return result;
        }

        public IQueryable<CarDetailDto> GetCarsByMileageRange(int minMileage, int maxMileage)
        {

            var result = (from car in _context.Cars
                          where car.Mileage >= minMileage && car.Mileage <= maxMileage
                          join brand in _context.Brands on car.BrandId equals brand.Id
                          join color in _context.Colors on car.ColorId equals color.Id
                          join fuel in _context.Fuels on car.FuelId equals fuel.Id
                          join transmission in _context.Transmissions on car.TransmissionId equals transmission.Id
                          join vehicle in _context.Vehicles on car.VehicleId equals vehicle.Id
                          join location in _context.Locations on car.LocationId equals location.Id
                          select new CarDetailDto
                          {
                              Id = car.Id,
                              BrandName = brand.Name,
                              ColorName = color.Name,
                              Fuel = fuel.Type,
                              Transmission = transmission.Type,
                              Vehicle = vehicle.Type,
                              LocationAddress = location.Address,
                              LocationCity = location.City,
                              LocationCountry = location.Country,
                              DailyPrice = car.DailyPrice,
                              Model = car.Model,
                              Year = car.Year,
                              Mileage = car.Mileage,
                              Description = car.Description,
                              Status = car.Status,
                          }).AsQueryable();

            return result;

        }

        public Dictionary<object, IQueryable<CarDetailDto>> GetGroupedCars(Func<CarDetailDto, object> groupBy, Expression<Func<CarDetailDto, bool>> filter = null)
        {

            var query = _context.Cars
                .Select(c => new CarDetailDto
                {
                    Id = c.Id,
                    BrandName = c.Brand.Name,
                    ColorName = c.Color.Name,
                    Model = c.Model,
                    Year = c.Year,
                    DailyPrice = c.DailyPrice,
                    Fuel = c.Fuel.Type,
                    Transmission = c.Transmission.Type,
                    Vehicle = c.Vehicle.Type,
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

            var cars = query.ToList();

            // Execute the query and group the results
            var groupedCars = query
                .GroupBy(groupBy)
                .ToDictionary(g => g.Key, g => g.AsQueryable());

            return groupedCars;
        }

    }
}

