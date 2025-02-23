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
    public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> entity)
        {
            // Table name
            entity.ToTable("CreditCards");

            // Primary key
            entity.HasKey(e => e.Id);

            // Properties
            entity.Property(e => e.Id)
                  .UseIdentityColumn()
                  .IsRequired();

            entity.Property(e => e.FullName)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(e => e.CardNumber)
                  .IsRequired()
                  .HasMaxLength(16)
                  .IsFixedLength();

            entity.Property(e => e.CardType)
                  .IsRequired()
                  .HasMaxLength(50);

            entity.Property(e => e.CardLimit)
                  .IsRequired() 
                  .HasColumnType("decimal(18,2)");

            entity.Property(e => e.Month)
                  .IsRequired()
                  .HasMaxLength(2);

            entity.Property(e => e.Year)
                  .IsRequired()
                  .HasMaxLength(4);

            entity.Property(e => e.Cvv)
                  .IsRequired()
                  .HasMaxLength(3);

            // Soft Delete
            entity.Property(e => e.IsDeleted)
                  .HasDefaultValue(false);

            entity.HasOne(c => c.Rental)
              .WithMany()
              .HasForeignKey(c => c.RentalId)
              .OnDelete(DeleteBehavior.Cascade); // Rental when deleted, CreditCard also deleted


            entity.HasBaseType<Payment>();
        }
    }
}
