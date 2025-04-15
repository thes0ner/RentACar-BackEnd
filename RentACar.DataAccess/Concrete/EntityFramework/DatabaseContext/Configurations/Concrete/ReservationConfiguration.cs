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

            entity.ToTable("Reservations");

            // Primary Key
            entity.HasKey(r => r.Id);

            entity.Property(r => r.Id)
                   .UseIdentityColumn()
                   .IsRequired();

            // Property Configurations
            entity.Property(r => r.PickUpDate)
                   .IsRequired()
                   .HasColumnType("datetime2");
            entity.Property(r => r.DropOffDate)
                   .IsRequired()
                    .HasColumnType("datetime2");

            entity.ToTable(t => t.HasCheckConstraint(
                    name: "CK_Reservations_DropOffDate_After_PickUpDate",
                        sql: "DropOffDate > PickUpDate"));

            entity.Property(r => r.TotalPrice)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            entity.Property(r => r.Notes)
                   .HasMaxLength(500);

            entity.Property(r => r.ReservationStatus)
                   .IsRequired()
                   .HasConversion<string>()  // Stores enum as string in DB
                   .HasMaxLength(20);


            // Car (Many-to-One)
            entity.HasOne(r => r.Car)
                   .WithMany(c => c.Reservations)
                   .HasForeignKey(r => r.CarId)
                   .OnDelete(DeleteBehavior.Restrict);

            // Customer (Many-to-One)
            entity.HasOne(r => r.Customer)
                   .WithMany(c => c.Reservations)
                   .HasForeignKey(r => r.CustomerId)
                   .OnDelete(DeleteBehavior.Restrict); 

            // Payment (One-to-One)
            entity.HasOne(r => r.Payment)
                   .WithOne(p => p.Reservation)
                   .HasForeignKey<Payment>(p => p.ReservationId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Indexes
            entity.HasIndex(r => r.PickUpDate);
            entity.HasIndex(r => r.DropOffDate);
            entity.HasIndex(r => r.ReservationStatus);
            entity.HasIndex(r => new { r.CustomerId, r.CarId });
        }
    }
}
