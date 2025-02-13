using RentACar.DataAccess.Abstract;
using RentACar.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Core.Entities.Enums;

namespace RentACar.DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal
    {

        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car { Id = 1, BrandId = 1, ColorId = 1, FuelId = 1, TransmissionId = 1, VehicleId = 1, LocationId = 1, DailyPrice = 50.00m, Model = "Corolla", Year = 2020, Mileage = 25000, Description = "Reliable compact car", Status = CarStatus.Available },
                new Car { Id = 2, BrandId = 2, ColorId = 2, FuelId = 2, TransmissionId = 2, VehicleId = 2, LocationId = 2, DailyPrice = 60.00m, Model = "Focus", Year = 2019, Mileage = 35000, Description = "Spacious sedan", Status = CarStatus.Available },
                new Car { Id = 3, BrandId = 3, ColorId = 3, FuelId = 1, TransmissionId = 1, VehicleId = 3, LocationId = 3, DailyPrice = 120.00m, Model = "X5", Year = 2021, Mileage = 15000, Description = "Luxury SUV", Status = CarStatus.Available },
                new Car { Id = 4, BrandId = 4, ColorId = 4, FuelId = 3, TransmissionId = 2, VehicleId = 4, LocationId = 4, DailyPrice = 200.00m, Model = "C-Class", Year = 2022, Mileage = 5000, Description = "Premium sedan", Status = CarStatus.Rented },
                new Car { Id = 5, BrandId = 5, ColorId = 5, FuelId = 1, TransmissionId = 1, VehicleId = 5, LocationId = 5, DailyPrice = 150.00m, Model = "A4", Year = 2021, Mileage = 12000, Description = "Luxury sedan", Status = CarStatus.Available },
                new Car { Id = 6, BrandId = 1, ColorId = 2, FuelId = 2, TransmissionId = 2, VehicleId = 3, LocationId = 1, DailyPrice = 75.00m, Model = "Highlander", Year = 2020, Mileage = 22000, Description = "Family SUV", Status = CarStatus.Available },
                new Car { Id = 7, BrandId = 2, ColorId = 3, FuelId = 1, TransmissionId = 1, VehicleId = 2, LocationId = 2, DailyPrice = 90.00m, Model = "Fusion", Year = 2018, Mileage = 45000, Description = "Affordable family sedan", Status = CarStatus.Available },
                new Car { Id = 8, BrandId = 3, ColorId = 4, FuelId = 3, TransmissionId = 2, VehicleId = 4, LocationId = 3, DailyPrice = 250.00m, Model = "i8", Year = 2022, Mileage = 10000, Description = "Electric sports car", Status = CarStatus.Available },
                new Car { Id = 9, BrandId = 4, ColorId = 5, FuelId = 2, TransmissionId = 1, VehicleId = 5, LocationId = 4, DailyPrice = 180.00m, Model = "GLC", Year = 2021, Mileage = 8000, Description = "Premium SUV", Status = CarStatus.Rented },
                new Car { Id = 10, BrandId = 5, ColorId = 1, FuelId = 1, TransmissionId = 2, VehicleId = 3, LocationId = 5, DailyPrice = 130.00m, Model = "A6", Year = 2020, Mileage = 15000, Description = "Luxury sedan with great performance", Status = CarStatus.Available }
            };

        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            var carToDelete = _cars.SingleOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetByCategoryId(int categoryId)
        {
            return _cars.Where(c => c.Id == categoryId).ToList();
        }

        public void Update(Car car)
        {
            // Aracı ID'ye göre buluyoruz
            var carToUpdate = _cars.SingleOrDefault(c => c.Id == car.Id);

            // Eğer araç bulunamazsa, işlem yapılmaz (isteğe bağlı hata fırlatılabilir)
            if (carToUpdate == null)
            {
                // İsterseniz burada bir hata fırlatabilirsiniz
                throw new ArgumentException("Car not found");
            }

            // Güncellenmiş değerlerle aracı güncelliyoruz
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.FuelId = car.FuelId;
            carToUpdate.TransmissionId = car.TransmissionId;
            carToUpdate.VehicleId = car.VehicleId;
            carToUpdate.LocationId = car.LocationId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Model = car.Model;
            carToUpdate.Year = car.Year;
            carToUpdate.Mileage = car.Mileage;
            carToUpdate.Description = car.Description;
            carToUpdate.Status = car.Status;

            // Ekstra olarak "UpdatedDate" güncellemesi yapmak isteyebilirsiniz
            carToUpdate.UpdatedDate = DateTime.UtcNow;
        }

    }
}
