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
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> entity)
        {
            //Table name
            entity.ToTable("Colors");

            // Primary key
            entity.HasKey(e => e.Id);


            // Index on Name for faster searches
            entity.HasIndex(e => e.Name).IsUnique();


            // Properties
            entity.Property(e => e.Id).UseIdentityColumn().IsRequired();
            entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnType("VARCHAR")
                    .HasConversion(name => name.Trim(), name => name.Trim());

            // Relationships
            entity.HasMany(e => e.Cars) // One-to-many relationship with Car
            .WithOne(c => c.Color)
            .HasForeignKey(c => c.ColorId)
            .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
