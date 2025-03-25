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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            //Table name
            entity.ToTable("Users");

            // Primary key
            entity.HasKey(e => e.Id);

           // Index on Email for faster searches
           entity.HasIndex(e => e.Email).IsUnique();

            // Properties
            entity.Property(e => e.Id).UseIdentityColumn().IsRequired();
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(80);
            entity.Property(e => e.PasswordHash).HasMaxLength(256);
            entity.Property(e => e.PasswordSalt).HasMaxLength(256);
            entity.Property(e => e.Status).IsRequired();
            entity.Property(e => e.IsDeleted).HasDefaultValue(false); // soft delete

            //Relationships
            entity.HasOne(e => e.Customer) // One-to-one relationship with Customer
                  .WithOne(c => c.User)
                  .HasForeignKey<Customer>(c => c.UserId)
                  .OnDelete(DeleteBehavior.Restrict) // if user is deleted, customer going to stay.
                  .IsRequired(false);
        }
    }
}
