using RentACar.Business.Concrete;
using RentACar.DataAccess.Concrete.EntityFramework;
using RentACar.DataAccess.Concrete.InMemory;
using RentACar.Entities.Concrete;

namespace RentACar.ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //CarManager carManager = new CarManager(new InMemoryCarDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            Brand brand1 = new Brand
            {
                Name = "Cherry",
                CreatedDate = System.DateTime.Now,
                UpdatedDate = System.DateTime.Now,
            };

            brandManager.Add(brand1);

            foreach (var brand in brandManager.GetAll().Result)
            {
                System.Console.WriteLine(brand.Name);
            }


        }
    }
}
