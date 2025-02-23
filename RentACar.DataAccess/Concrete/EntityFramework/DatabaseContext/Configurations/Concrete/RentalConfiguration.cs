using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DataAccess.Concrete.EntityFramework.DatabaseContext.Configurations.Concrete
{
    public class RentalConfiguration : IEntityTypeConfiguration<Rental>
    {
        public void Configure(EntityTypeBuilder<Rental> entity)
        {
            //Table name
            entity.ToTable("Rentals");

            // Primary key
            entity.HasKey(e => e.Id);

            // Properties
            entity.Property(e => e.Id).UseIdentityColumn().IsRequired();
            entity.Property(e => e.RentDate).IsRequired();
            entity.Property(e => e.ReturnDate).IsRequired(false);
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18,2)");
            entity.Property(e => e.IsReturned).IsRequired();
            entity.Property(e => e.IsDeleted).HasDefaultValue(false); // Soft delete



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
        }
    }
}
