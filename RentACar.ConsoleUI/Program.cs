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
            CarManagerTest();
            //BrandManagerTest();
            //ColorManagerTest();
            //CreditCardManagerTest();
        }




        public static void CarManagerTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarsAsync();
            //var result = carManager.GetSingleAsync(1);
            //var result = carManager.GetCarDetailsByIdAsync(1);
            //var result = carManager.GetCarsDetailsAsync();


            //var result = carManager.GetCarsByBrandAsync("Yugo");


            //var result = carManager.GetCarsByColorAsync("Black");
            //var result = carManager.GetCarsByPriceRangeAsync();
            //var result = carManager.GetCarsByAvailabilityAsync();
            //var result = carManager.GetCarsByModelYearAsync();
            //var result = carManager.GetCarsByFuelTypeAsync();
            //var result = carManager.GetCarsByTransmissionTypeAsync();
            //var result = carManager.GetCarsByModelYearRangeAsync();
            //var result = carManager.GetCarsByMileageRangeAsync();



            //Console.WriteLine($"{result.Result.Data.BrandName}");


            foreach (var res in result.Result.Data)
            {
                Console.WriteLine($"{res.Id}");

                //Console.WriteLine($"Id: {res.Id} {res.BrandName} {res.ColorName} {res.Year} {res.DailyPrice} {res.Description} {res.Mileage} {res.LocationCity} {res.Model} {res.Status}");
            }
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
