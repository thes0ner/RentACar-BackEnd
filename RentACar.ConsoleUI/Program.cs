using RentACar.Business.Concrete;
using RentACar.DataAccess.Concrete.EntityFramework;
using RentACar.DataAccess.Concrete.InMemory;
using RentACar.Core.Entities.Concrete;
using RentACar.Core.Entities.DTO_s;

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

            //Console.WriteLine($"{result.Result.Data.DailyPrice}");


            foreach (var res in result.Result.Data)
            {
                Console.WriteLine($"Id:{res.Id} {res.Description}");
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
