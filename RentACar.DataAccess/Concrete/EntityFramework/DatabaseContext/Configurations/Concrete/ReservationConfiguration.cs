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
    public class ReservationConfiguration : IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> entity)
        {
            //Table name
            entity.ToTable("Reservations");

            // Primary key
            entity.HasKey(e => e.Id);

            // Properties
            entity.Property(e => e.Id).UseIdentityColumn().IsRequired();
            entity.Property(e => e.ReservationDate).IsRequired();
            entity.Property(e => e.StartDate).IsRequired();
            entity.Property(e => e.EndDate).IsRequired();
            entity.Property(e => e.IsConfirmed).IsRequired();
            entity.Property(e => e.IsCancelled).HasDefaultValue(false);


            entity.HasOne(e => e.Car) // One-to-many relationship with Car
                  .WithMany(c => c.Reservations)
                  .HasForeignKey(e => e.CarId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Customer) // One-to-many relationship with Customer
                  .WithMany(c => c.Reservations)
                  .HasForeignKey(e => e.CustomerId)
                  .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
