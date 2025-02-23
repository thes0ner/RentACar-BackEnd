using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Core.Entities.Abstract;
using RentACar.Entities.Concrete;
using RentACar.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DataAccess.Concrete.EntityFramework.DatabaseContext.Configurations.Concrete
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> entity)
        {
            //Table name
            entity.ToTable("Cars");

            // Primary key
            entity.HasKey(e => e.Id);

            // Properties
            entity.Property(e => e.Id).UseIdentityColumn().IsRequired();
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
        }
    }
}
