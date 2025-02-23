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
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> entity)
        {
            //Table name
            entity.ToTable("Vehicles");

            // Primary key
            entity.HasKey(e => e.Id);

            entity.HasIndex(e => e.Type).IsUnique().HasFilter("LOWER(Name)"); ;

            // Properties
            entity.Property(e => e.Type).IsRequired().HasMaxLength(50);

            //Relationships
            entity.HasMany(e => e.Cars) // One-to-many relationship with Car
                .WithOne(c => c.Vehicle)
                .HasForeignKey(c => c.VehicleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
