using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using RentACar.Core.Entities.Abstract;
using RentACar.Entities.Concrete;
using RentACar.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
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

            modelBuilder.Entity<Car>(entity =>
            {
                //Table name
                entity.ToTable("Cars");

                // Primary key
                entity.HasKey(e => e.Id);

                // Properties
                entity.Property(e => e.BrandId).IsRequired();
                entity.Property(e => e.ColorId).IsRequired();
                entity.Property(e => e.FuelId).IsRequired();
                entity.Property(e => e.TransmissionId).IsRequired();
                entity.Property(e => e.VehicleId).IsRequired();
                entity.Property(e => e.LocationId).IsRequired();
                entity.Property(e => e.Model).IsRequired().HasMaxLength(50);
                entity.Property(e => e.DailyPrice).HasColumnType("decimal(18,2)");
                entity.HasIndex(e => e.Plate).IsUnique();
                entity.Property(e => e.Description).HasMaxLength(500);
                entity.Property(e => e.Year).IsRequired();
                entity.Property(e => e.Status).IsRequired().HasConversion(v => v.ToString(), v => (CarStatus)Enum.Parse(typeof(CarStatus), v))
                                        .IsRequired();
                entity.Property(e => e.Mileage).IsRequired();


                // Relationships

                entity.HasOne(e => e.Brand) // One-to-many relationship with Brand
                      .WithMany(b => b.Cars)
                      .HasForeignKey(e => e.BrandId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Color) // One-to-many relationship with Color
                      .WithMany()
                      .HasForeignKey(e => e.ColorId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Fuel) // One-to-many relationship with FuelType
                      .WithMany()
                      .HasForeignKey(e => e.FuelId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Transmission) // One-to-many relationship with TransmissionType
                      .WithMany()
                      .HasForeignKey(e => e.TransmissionId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Vehicle) // One-to-many relationship with VehicleType
                      .WithMany()
                      .HasForeignKey(e => e.VehicleId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Location) // One-to-many relationship with Location
                        .WithMany(l => l.Cars)
                        .HasForeignKey(e => e.LocationId)
                        .OnDelete(DeleteBehavior.Restrict);

                entity.HasMany(e => e.CarImages) // One-to-many relationship with CarImage
                      .WithOne(ci => ci.Car)
                      .HasForeignKey(ci => ci.CarId)
                      .OnDelete(DeleteBehavior.Cascade);

                // Index on Model for faster searches
                entity.HasIndex(e => e.Model);
            });


            modelBuilder.Entity<CarImage>(entity =>
            {
                //Table name
                entity.ToTable("CarImages");

                // Primary key
                entity.HasKey(e => e.Id);

                // Properties
                entity.Property(e => e.Id).IsRequired();
                entity.Property(e => e.ImagePath).HasMaxLength(255).IsRequired();
                entity.Property(e => e.Date).IsRequired();

                // Relationships
                entity.HasOne(ci => ci.Car) // One-to-many relationship with Car
                .WithMany(c => c.CarImages)
                .HasForeignKey(ci => ci.CarId)
                .OnDelete(DeleteBehavior.Cascade);
            });


            modelBuilder.Entity<Brand>(entity =>
            {
                //Table name
                entity.ToTable("Brands");

                // Primary key
                entity.HasIndex(e => e.Name).IsUnique().HasFilter("LOWER(Name)");

                // Properties
                entity.Property(e => e.Id).IsRequired();
                entity.Property(e => e.Name)
                       .IsRequired()
                       .HasMaxLength(50)
                       .HasColumnType("VARCHAR")
                       .HasConversion(name => name.Trim(), name => name.Trim());

                // Index on Name for faster searches
                entity.HasIndex(e => e.Name).IsUnique();

                // Relationships
                entity.HasMany(e => e.Cars) // One-to-many relationship with Car
                      .WithOne(c => c.Brand)
                      .HasForeignKey(c => c.BrandId)
                      .OnDelete(DeleteBehavior.Restrict);
            });


            modelBuilder.Entity<Color>(entity =>
            {
                //Table name
                entity.ToTable("Colors");

                // Primary key
                entity.HasKey(e => e.Id);

                // Properties
                entity.Property(e => e.Id).IsRequired();
                entity.Property(e => e.Name)
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR")
                        .HasConversion(name => name.Trim(), name => name.Trim());

                // Index on Name for faster searches
                entity.HasIndex(e => e.Name).IsUnique().HasFilter("LOWER(Name)");

                // Relationships
                entity.HasMany(e => e.Cars) // One-to-many relationship with Car
                .WithOne(c => c.Color)
                .HasForeignKey(c => c.ColorId)
                .OnDelete(DeleteBehavior.Restrict);
            });


            // This two needs to be implemented.
            modelBuilder.Entity<CreditCard>(entity =>
            {
                ////Table name
                //entity.ToTable("CreditCards");

                //// Primary key
                //entity.HasKey(e => e.Id);

                //// Properties

                //entity.Property(e => e.FullName).IsRequired().HasMaxLength(100);
                //entity.Property(e => e.CardNumber).IsRequired().HasMaxLength(16);
                //entity.Property(e => e.Month).IsRequired().HasMaxLength(2);
                //entity.Property(e => e.Year).IsRequired().HasMaxLength(4);
                //entity.Property(e => e.Cvv).IsRequired().HasMaxLength(3);

            });
            modelBuilder.Entity<Bank>(entity =>
            {

            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customers");

                // Primary key
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseIdentityColumn().IsRequired();


                // Properties
                entity.Property(e => e.Id).IsRequired();
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(50);
                entity.Property(e => e.PhoneNumber)
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR")
                        .HasConversion(p => p.Trim(), p => p.Trim());

                entity.Property(e => e.Address).HasMaxLength(100);
                entity.Property(e => e.City).HasMaxLength(50);
                entity.Property(e => e.Country).HasMaxLength(50);
                entity.Property(e => e.CustomerStatus)
                                    .HasConversion(v => v.ToString(), v => (CustomerStatus)Enum.Parse(typeof(CustomerStatus), v))
                                    .IsRequired();

                // Index on Email for faster searches
                entity.HasIndex(e => e.Email).IsUnique().HasFilter("LOWER(Email)");

                //Relationships
                entity.HasOne(e => e.User) // One-to-one relationship with User
                      .WithOne(u => u.Customer)
                      .HasForeignKey<Customer>(e => e.UserId)
                      .OnDelete(DeleteBehavior.Cascade); // when customer is deleted, deletes the user as well.

                entity.HasMany(e => e.Reservations)
                      .WithOne(r => r.Customer)
                      .HasForeignKey(r => r.CustomerId)
                      .OnDelete(DeleteBehavior.Restrict); // when customer is deleted, Reservations needs to stay.

                entity.HasMany(e => e.Rentals)
                      .WithOne(r => r.Customer)
                      .HasForeignKey(r => r.CustomerId)
                      .OnDelete(DeleteBehavior.Restrict); // when customer is deleted, Rentals needs to stay.

            });

            modelBuilder.Entity<User>(entity =>
            {
                //Table name
                entity.ToTable("Users");

                // Primary key
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseIdentityColumn().IsRequired();


                // Index on Email for faster searches
                entity.HasIndex(e => e.Email).IsUnique().HasFilter("LOWER(Email)");

                // Properties
                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(80);
                entity.Property(e => e.PasswordHash).HasMaxLength(256);
                entity.Property(e => e.PasswordSalt).HasMaxLength(256);
                entity.Property(e => e.Status).IsRequired();

                //Relationships
                entity.HasOne(e => e.Customer) // One-to-one relationship with Customer
                      .WithOne(c => c.User)
                      .HasForeignKey<Customer>(c => c.UserId)
                      .OnDelete(DeleteBehavior.Restrict) // if user is deleted, customer going to stay.
                      .IsRequired(false);
            });

            modelBuilder.Entity<Rental>(entity =>
            {
                //Table name
                entity.ToTable("Rentals");

                // Primary key
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseIdentityColumn().IsRequired();

                // Properties
                entity.Property(e => e.RentDate).IsRequired();
                entity.Property(e => e.ReturnDate).IsRequired(false);
                entity.Property(e => e.TotalPrice).HasColumnType("decimal(18,2)");
                entity.Property(e => e.IsReturned).IsRequired();


                // Relationships
                entity.HasOne(e => e.Car) // One-to-many relationship with Car
                      .WithMany(c => c.Rentals)
                      .HasForeignKey(e => e.CarId)
                      .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(e => e.Customer) // One-to-many relationship with Customer
                      .WithMany(c => c.Rentals)
                      .HasForeignKey(e => e.CustomerId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Invoice) // One-to-one relationship with Invoice
                        .WithOne(i => i.Rental)
                        .HasForeignKey<Invoice>(e => e.RentalId)
                        .OnDelete(DeleteBehavior.Cascade);

                entity.HasMany(e => e.Payments) // One-to-many relationship with Payment
                      .WithOne(p => p.Rental)
                      .HasForeignKey(p => p.RentalId)
                      .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Reservation>(entity =>
            {
                //Table name
                entity.ToTable("Reservations");

                // Primary key
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseIdentityColumn().IsRequired();

                // Properties
                entity.Property(e => e.ReservationDate).IsRequired();
                entity.Property(e => e.StartDate).IsRequired();
                entity.Property(e => e.EndDate).IsRequired();
                entity.Property(e => e.IsConfirmed).IsRequired();


                entity.HasOne(e => e.Car) // One-to-many relationship with Car
                      .WithMany(c => c.Reservations)
                      .HasForeignKey(e => e.CarId)
                      .OnDelete(DeleteBehavior.Restrict);

                entity.HasOne(e => e.Customer) // One-to-many relationship with Customer
                      .WithMany(c => c.Reservations)
                      .HasForeignKey(e => e.CustomerId)
                      .OnDelete(DeleteBehavior.NoAction);
            });


            modelBuilder.Entity<Location>(entity =>
            {

                //Table name
                entity.ToTable("Locations");

                //Primary key
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).UseIdentityColumn().IsRequired();

                //Properties
                entity.Property(e => e.Address).IsRequired().HasMaxLength(100);
                entity.Property(e => e.City).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Country).IsRequired().HasMaxLength(50);

                //Relationships
                entity.HasMany(e => e.Cars) // One-to-many relationship with Car
                      .WithOne(c => c.Location)
                      .HasForeignKey(c => c.LocationId)
                      .OnDelete(DeleteBehavior.Restrict);

            });


            modelBuilder.Entity<Fuel>(entity =>
            {
                //Table name
                entity.ToTable("Fuels");

                // Primary key
                entity.HasKey(e => e.Id);

                // Properties
                entity.Property(e => e.Type).IsRequired().HasMaxLength(50);

                //Relationships
                entity.HasMany(e => e.Cars) // One-to-many relationship with Car
                      .WithOne(c => c.Fuel)
                      .HasForeignKey(c => c.FuelId)
                      .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Transmission>(entity =>
            {
                //Table name
                entity.ToTable("Transmissions");

                // Primary key
                entity.HasKey(e => e.Id);

                // Properties
                entity.Property(e => e.Type).IsRequired().HasMaxLength(50);

                //Relationships
                entity.HasMany(e => e.Cars) // One-to-many relationship with Car
                    .WithOne(c => c.Transmission)
                    .HasForeignKey(c => c.TransmissionId)
                    .OnDelete(DeleteBehavior.Cascade);
            });


            modelBuilder.Entity<Vehicle>(entity =>
            {
                //Table name
                entity.ToTable("Vehicles");

                // Primary key
                entity.HasKey(e => e.Id);

                // Properties
                entity.Property(e => e.Type).IsRequired().HasMaxLength(50);

                //Relationships
                entity.HasMany(e => e.Cars) // One-to-many relationship with Car
                    .WithOne(c => c.Vehicle)
                    .HasForeignKey(c => c.VehicleId)
                    .OnDelete(DeleteBehavior.Cascade);
            });


            modelBuilder.Entity<Invoice>(entity =>
            {
                //Table name
                entity.ToTable("Invoices");

                // Primary key
                entity.HasKey(e => e.Id);

                // Properties
                entity.Property(e => e.TotalAmount).HasColumnType("decimal(18,2)");
                entity.Property(e => e.PaidAmount).HasColumnType("decimal(18,2)");
                entity.Property(e => e.Balance).HasColumnType("decimal(18,2)");
                entity.Property(e => e.InvoiceDate).IsRequired();
                entity.Property(e => e.DueDate).IsRequired();
                entity.Property(e => e.InvoiceStatus).IsRequired();


                // Relationships
                entity.HasOne(e => e.Rental) // One-to-one relationship with Rental
                      .WithOne(r => r.Invoice)
                      .HasForeignKey<Invoice>(e => e.RentalId)
                      .OnDelete(DeleteBehavior.Cascade);

            });
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
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Fuel> Fuels { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Rental> Rentals { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Transmission> Transmissions { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
    }

}
