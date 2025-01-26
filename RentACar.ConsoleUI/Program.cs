using RentACar.Business.Concrete;
using RentACar.DataAccess.Concrete.EntityFramework;
using RentACar.DataAccess.Concrete.InMemory;
using RentACar.Core.Entities.Concrete;

namespace RentACar.ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //CarManager carManager = new CarManager(new InMemoryCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            Brand jaguar = new Brand();

            jaguar.Name = "Renault";





            brandManager.Add(jaguar).Wait();
            Console.WriteLine("Added.");


            foreach (var brand in brandManager.GetAll().Result)
            {
                System.Console.WriteLine(brand.Name);
            }


        }
    }
}
