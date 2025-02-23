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
            entity.Property(e => e.CustomerStatus).HasConversion(v => v.ToString(), v => (CustomerStatus)Enum.Parse(typeof(CustomerStatus), v)).IsRequired();
            entity.Property(e => e.IsDeleted).HasDefaultValue(false); // soft delete

            entity.HasIndex(e => e.Email).IsUnique();

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
