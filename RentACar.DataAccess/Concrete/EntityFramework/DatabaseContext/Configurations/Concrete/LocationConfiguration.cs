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
    public class LocationConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> entity)
        {
            //Table name
            entity.ToTable("Locations");

            //Primary key
            entity.HasKey(e => e.Id);

            // Index - unique constraint
            entity.HasIndex(e => new { e.Address, e.City, e.Country }).IsUnique();

            //Properties
            entity.Property(e => e.Id).UseIdentityColumn().IsRequired();
            entity.Property(e => e.Address).IsRequired().HasMaxLength(100);
            entity.Property(e => e.City).IsRequired().HasMaxLength(50);
            entity.Property(e => e.Country).IsRequired().HasMaxLength(50);

            //Relationships
            entity.HasMany(e => e.Cars) // One-to-many relationship with Car
                  .WithOne(c => c.Location)
                  .HasForeignKey(c => c.LocationId)
                  .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
