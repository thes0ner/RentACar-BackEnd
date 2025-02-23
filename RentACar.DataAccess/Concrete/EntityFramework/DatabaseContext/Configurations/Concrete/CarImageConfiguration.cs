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
    public class CarImageConfiguration : IEntityTypeConfiguration<CarImage>
    {
        public void Configure(EntityTypeBuilder<CarImage> entity)
        {
            //Table name
            entity.ToTable("CarImages");

            // Primary key
            entity.HasKey(e => e.Id);

            // Properties
            entity.Property(e => e.Id).UseIdentityColumn().IsRequired();
            entity.Property(e => e.ImagePath).HasMaxLength(255).IsRequired();
            entity.Property(e => e.Date).IsRequired();

            // Relationships
            entity.HasOne(ci => ci.Car) // One-to-many relationship with Car
            .WithMany(c => c.CarImages)
            .HasForeignKey(ci => ci.CarId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
