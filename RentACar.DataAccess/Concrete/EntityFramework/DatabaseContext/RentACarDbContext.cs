using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using RentACar.Core.Entities.Abstract;
using RentACar.DataAccess.Concrete.EntityFramework.DatabaseContext.Configurations.Concrete;
using RentACar.Entities.Concrete;
using RentACar.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DataAccess.Concrete.EntityFramework.DatabaseContext
{

    // Represents the database context for the RentACar application.
    public class RentACarDbContext : DbContext
    {
        public RentACarDbContext()
        {
        }

        public RentACarDbContext(DbContextOptions options) : base(options)
        {

        }


        /// <summary>
        /// Configures the entity mappings and relationships.
        /// </summary>
        /// <param name="modelBuilder">The model builder used to configure the entities.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.GetInterfaces().Any(gi => gi.IsGenericType && gi.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>)));

            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }


            // TPH - Table Per Hierarchy(Derived classes, will use one table)
            modelBuilder.Entity<Payment>()
                .HasDiscriminator<string>("Payments")
                .HasValue<CreditCard>("CreditCard")
                .HasValue<BankTransfer>("BankTransfer");

        }


        // This method is called when the model for a derived context has been initialized, but before the model has been locked down and used to initialize the context.
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            // Set the CreatedDate and UpdatedDate properties of the entities
            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                if (data.State == EntityState.Deleted)
                    continue;

                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.Now,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.Now
                };
            }

            return base.SaveChangesAsync(cancellationToken);

        }


        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<CarImage> CarImages { get; set; }
        public DbSet<CreditCard> CreditCards { get; set; }
        public DbSet<BankTransfer> BankTransfers { get; set; }
        public DbSet<Fuel> Fuels { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
    }

}
