using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RentACar.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DataAccess.Concrete.EntityFramework.DatabaseContext
{
    public static class ServiceRegistration
    {

        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            //services.AddDbContext<RentACarDbContext>(option => option.UseSqlServer(@"Server=DESKTOP-1Q8O3E1\SQLEXPRESS;Database=RentACarDb;Trusted_Connection=true;MultipleActiveResultSets=false;TrustServerCertificate=Yes"));

            services.AddDbContext<RentACarDbContext>(option => option.UseSqlServer(Configuration.ConnectionString));

            services.AddScoped<IBrandDal, EfBrandDal>();
            services.AddScoped<ICarDal, EfCarDal>();
            services.AddScoped<IColorDal, EfColorDal>();
            services.AddScoped<ICreditCardDal, EfCreditCardDal>();
            services.AddScoped<ICustomerDal, EfCustomerDal>();
            services.AddScoped<IFuelDal, EfFuelDal>();
            services.AddScoped<IInvoiceDal, EfInvoiceDal>();
            services.AddScoped<ILocationDal, EfLocationDal>();
            services.AddScoped<IRentalDal, EfRentalDal>();
            services.AddScoped<ITransmissionDal, EfTransmissionDal>();
            services.AddScoped<IVehicleDal, EfVehicleDal>();

            return services;
        }
    }
}
