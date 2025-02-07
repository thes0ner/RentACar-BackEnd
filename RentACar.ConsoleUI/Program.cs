using RentACar.Business.Concrete;
using RentACar.DataAccess.Concrete.EntityFramework;
using RentACar.DataAccess.Concrete.InMemory;
using RentACar.Core.Entities.Concrete;
using RentACar.Core.Entities.DTO_s;
using Microsoft.VisualBasic.FileIO;

namespace RentACar.ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CarManagerGroupByXTest();
            //BrandManagerTest();
            //ColorManagerTest();
            //CreditCardManagerTest();
        }


        public static void CarManagerGroupByXTest()
        {
            var carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarsGroupByAvailabilityAsync(0);

            if (result.Result.Success)
            {
                Console.WriteLine("\n----- Car List -----");
                foreach (var group in result.Result.Data)
                {
                    Console.WriteLine($"Car by transmission type: {group.Key}\n");

                    foreach (var car in group.Value)
                    {
                        Console.WriteLine($"Brand: {car.BrandName}");
                        Console.WriteLine($"Model: {car.Model}");
                        Console.WriteLine($"Year: {car.Year}");
                        Console.WriteLine($"Color : {car.ColorName}");
                        Console.WriteLine($"Daily Price: {car.DailyPrice} $");
                        Console.WriteLine($"Fuel Type: {car.FuelType}");
                        Console.WriteLine($"Transmission Type: {car.TransmissionType}");
                        Console.WriteLine($"Mielage: {car.Mileage}");

                        Console.WriteLine("-------------------------");
                    }
                }
            }
            else
            {
                Console.WriteLine(result.Result.Message); // Hata mesajını göster
            }

            Console.ReadLine();
        }

        public static void CarManagerGroupByBrandTest()
        {
            var carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarsGroupByBrandAsync("BMW");

            if (result.Result.Success)
            {
                Console.WriteLine("\n----- Car List -----");
                foreach (var group in result.Result.Data)
                {
                    Console.WriteLine($"\nBrand: {group.Key}\n");

                    foreach (var car in group.Value)
                    {
                        Console.WriteLine($"Model: {car.Model}");
                        Console.WriteLine($"Year: {car.Year}");
                        Console.WriteLine($"Color : {car.ColorName}");
                        Console.WriteLine($"Daily Price: {car.DailyPrice} $");
                        Console.WriteLine($"Fuel Type: {car.FuelType}");
                        Console.WriteLine($"Vites Türü: {car.TransmissionType}");
                        Console.WriteLine($"Mielage: {car.Mileage}");

                        Console.WriteLine("-------------------------");
                    }
                }
            }
            else
            {
                Console.WriteLine(result.Result.Message); // Hata mesajını göster
            }

            Console.ReadLine();



            //var result = carManager.GetCarsAsync();
            //var result = carManager.GetSingleAsync(1);
            //var result = carManager.GetCarDetailsByIdAsync(1);
            //var result = carManager.GetCarsDetailsAsync();
            //var result = carManager.GetCarsByBrandAsync("Yugo");
            //var result = carManager.GetCarsByColorAsync("Black");
            //var result = carManager.GetCarsByPriceRangeAsync(5, 300);
            //var result = carManager.GetCarsByAvailabilityAsync(0);
            //var result = carManager.GetCarsByModelYearAsync(2020);
            //var result = carManager.GetCarsByFuelTypeAsync("Hybrid");
            //var result = carManager.GetCarsByTransmissionTypeAsync("Automatic");
            //var result = carManager.GetCarsByModelYearRangeAsync(2018,2023);
            //var result = carManager.GetCarsByMileageRangeAsync(1000,10000);


            //Console.WriteLine($"{result.Result.Data.BrandName}");


            //foreach (var res in result.Result.Data)
            //{
            //    //Console.WriteLine($"{res.Id} {res.BrandName}");

            //    //Console.WriteLine($"Id: {res.Id} {res.BrandName} {res.ColorName} {res.Year} {res.DailyPrice} {res.Description} {res.Mileage} {res.LocationCity} {res.Model} {res.Status}");
            //}
        }



        public static void BrandManagerTest()
        {
            BrandManager brandManager = new(new EfBrandDal());

            //var result = brandManager.GetSingleAsync(0);
            var result = brandManager.GetBrandsAsync();

            foreach (var res in result.Result.Data)
            {
                Console.WriteLine($"{res.Name}");
            }
        }

        public static void ColorManagerTest()
        {
            ColorManager colorManager = new(new EfColorDal());

            //var result = colorManager.GetColorsAsync();
            var result = colorManager.GetSingleAsync(1);

            Console.WriteLine($"{result.Result.Data.Name}");


            //foreach (var res in result.Result.Data)
            //{
            //    Console.WriteLine($"{res.Name}");
            //}
        }


        public static void CreditCardManagerTest()
        {
            CreditCardManager creditCardManager = new(new EfCreditCardDal());

            //var result = colorManager.GetColorsAsync();
            var result = creditCardManager.GetSingleAsync(1);

            Console.WriteLine($"{result.Result.Data.FullName}");


            //foreach (var res in result.Result.Data)
            //{
            //    Console.WriteLine($"{res.FullName}");
            //}
        }
    }
}
