using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Entities.Concrete;
using RentACar.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DataAccess.Concrete.EntityFramework.DatabaseContext.Configurations.Concrete
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> entity)
        {
            entity.ToTable("Customers");

            // Primary key
            entity.HasKey(e => e.Id);


            // Properties
            entity.Property(e => e.Id).UseIdentityColumn().IsRequired();
            entity.Property(e => e.FirstName).HasMaxLength(50).IsRequired();
            entity.Property(e => e.LastName).HasMaxLength(50).IsRequired();
            entity.Property(e => e.Email).HasMaxLength(50);

            entity.Property(e => e.PhoneNumber)
                        .HasMaxLength(20)
                        .HasColumnType("VARCHAR")
                        .HasConversion(p => string.IsNullOrWhiteSpace(p) ? null : p.Trim(),
                            p => p.Trim());


            entity.Property(e => e.Address).HasMaxLength(100);
            entity.Property(e => e.City).HasMaxLength(50);
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.CustomerStatus).HasConversion(v => v.ToString(), v => (CustomerStatus)Enum.Parse(typeof(CustomerStatus), v)).IsRequired();
            entity.Property(e => e.IsDeleted).HasDefaultValue(false); // soft delete

            entity.HasIndex(e => e.Email)
                    .IsUnique()
                        .HasFilter("[IsDeleted] = 0");

            entity.HasIndex(e => e.PhoneNumber)
                    .IsUnique()
                        .HasFilter("[PhoneNumber] IS NOT NULL AND [IsDeleted] = 0");

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

        }
    }
}
