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
    public class FuelConfiguration : IEntityTypeConfiguration<Fuel>
    {
        public void Configure(EntityTypeBuilder<Fuel> entity)
        {
            //Table name
            entity.ToTable("Fuels");

            // Primary key
            entity.HasKey(e => e.Id);

            entity.HasIndex(e => e.Type).IsUnique();

            // Properties
            entity.Property(e => e.Id).UseIdentityColumn().IsRequired();
            entity.Property(e => e.Type).IsRequired().HasMaxLength(50);


            //Relationships
            entity.HasMany(e => e.Cars) // One-to-many relationship with Car
                  .WithOne(c => c.Fuel)
                  .HasForeignKey(c => c.FuelId)
                  .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
