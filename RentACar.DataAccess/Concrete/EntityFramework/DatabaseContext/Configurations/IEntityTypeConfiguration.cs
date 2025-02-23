using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RentACar.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DataAccess.Concrete.EntityFramework.DatabaseContext.Configurations
{
    public interface IEntityTypeConfiguration<T> where T : class, IEntity
    {
        void Configure(EntityTypeBuilder<T> entity);
    }
}
