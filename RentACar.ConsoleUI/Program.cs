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

            ColorManager colorManager = new ColorManager(new EfColorDal());


            foreach (var item in colorManager.GetAll().Result)
            {

            }
        }
    }
}
