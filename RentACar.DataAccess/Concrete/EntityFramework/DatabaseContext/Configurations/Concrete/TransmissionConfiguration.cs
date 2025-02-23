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
    public class TransmissionConfiguration : IEntityTypeConfiguration<Transmission>
    {
        public void Configure(EntityTypeBuilder<Transmission> entity)
        {
            //Table name
            entity.ToTable("Transmissions");

            // Primary key
            entity.HasKey(e => e.Id);

            entity.HasIndex(e => e.Type).IsUnique().HasFilter("LOWER(Name)");

            // Properties
            entity.Property(e => e.Id).UseIdentityColumn().IsRequired();
            entity.Property(e => e.Type).IsRequired().HasMaxLength(50);

            //Relationships
            entity.HasMany(e => e.Cars) // One-to-many relationship with Car
                .WithOne(c => c.Transmission)
                .HasForeignKey(c => c.TransmissionId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
