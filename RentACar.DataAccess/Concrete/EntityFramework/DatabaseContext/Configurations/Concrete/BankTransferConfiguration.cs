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
    public class BankTransferConfiguration : IEntityTypeConfiguration<BankTransfer>
    {
        public void Configure(EntityTypeBuilder<BankTransfer> entity)
        {
            // Table Name
            entity.ToTable("BankTransfers");

            // Primary Key
            entity.HasKey(b => b.Id);

            // Properties

            entity.Property(b => b.Id)
                  .UseIdentityColumn()
                  .IsRequired();

            entity.Property(b => b.BankName)
                  .IsRequired()
                  .HasMaxLength(100);

            entity.Property(b => b.AccountNumber)
                  .IsRequired()
                  .HasMaxLength(20);

            entity.Property(b => b.IBAN)
                  .IsRequired()
                  .HasMaxLength(34);

            entity.Property(b => b.IsDeleted)
                  .HasDefaultValue(false); // Soft delete

            // Relationships
            entity.HasOne(b => b.Rental)
                  .WithMany() // BankTransfer has one Rental, Rental has many BankTransfer
                  .HasForeignKey(b => b.RentalId)
                  .OnDelete(DeleteBehavior.Cascade); // Rental when deleted, Bank also deleted

            entity.HasBaseType<Payment>();
        }
    }
}
