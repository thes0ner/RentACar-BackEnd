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
            CreditCardManager creditCardManager = new CreditCardManager(new EfCreditCardDal());
            FuelTypeManager fuelTypeManager = new FuelTypeManager(new EfFuelTypeDal());
            InvoiceManager invoiceManager = new InvoiceManager(new EfInvoiceDal());
            LocationManager locationManager = new LocationManager(new EfLocationDal());
            RentalManager rentalManager = new RentalManager(new EfRentalDal());
            TransmissionTypeManager transmissionTypeManager = new TransmissionTypeManager(new EfTransmissionTypeDal());
            VehicleTypeManager vehicleTypeManager = new VehicleTypeManager(new EfVehicleTypeDal());



            //GetAll()

            foreach (var item in vehicleTypeManager.GetVehicleTypesAsync().Result)
            {
                Console.WriteLine($"ID: {item.Id} Name: {item.Type} ");
            }

            //GetSingle()

            var result = vehicleTypeManager.GetSingleAsync(1).Result;
            Console.WriteLine($"Id : {result.Id} Name: {result.Type}");
        }
    }
}
