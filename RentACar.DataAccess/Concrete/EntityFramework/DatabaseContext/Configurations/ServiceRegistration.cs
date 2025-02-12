using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RentACar.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DataAccess.Concrete.EntityFramework.DatabaseContext.Configurations
{
    public static class ServiceRegistration
    {

        // Extension method to register persistence-related services.
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {

            // Register RentACarDbContext with SQL server using the connection string from Configuration.
            services.AddDbContext<RentACarDbContext>(option => option.UseSqlServer(Configuration.ConnectionString));


            // Register data access layers (DAL) with their corresponding implementations
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

            // Return the configured IServiceCollection for method chaining
            return services;
        }
    }
}
