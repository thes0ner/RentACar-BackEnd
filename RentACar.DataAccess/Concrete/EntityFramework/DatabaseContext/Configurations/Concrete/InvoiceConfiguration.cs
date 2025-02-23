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
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> entity)
        {
            //Table name
            entity.ToTable("Invoices");

            // Primary key
            entity.HasKey(e => e.Id);
            entity.HasIndex(e => e.InvoiceNumber).IsUnique();

            // Decimal Properties
            entity.Property(e => e.TotalAmount)
                  .HasColumnType("decimal(18,2)")
                  .IsRequired();

            entity.Property(e => e.PaidAmount)
                  .HasColumnType("decimal(18,2)")
                  .IsRequired()
                  .HasDefaultValue(0);

            entity.Property(e => e.Balance)
                  .HasColumnType("decimal(18,2)")
                  .HasComputedColumnSql("[TotalAmount] - [PaidAmount]");

            entity.Property(e => e.InvoiceDate)
                  .IsRequired()
                  .HasDefaultValueSql("GETDATE()");

            entity.Property(e => e.DueDate)
                  .IsRequired();

            entity.Property(e => e.InvoiceStatus)
                  .IsRequired()
                  .HasConversion(v => v.ToString(), v => (InvoiceStatus)Enum.Parse(typeof(InvoiceStatus), v))
                                .IsRequired();

            // Soft Delete
            entity.Property(e => e.IsDeleted)
                  .HasDefaultValue(false);

            // One-to-One Relationship with Rental
            entity.HasOne(e => e.Rental)
                  .WithOne(r => r.Invoice)
                  .HasForeignKey<Invoice>(e => e.RentalId)
                  .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
