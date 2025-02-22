using RentACar.Core.DataAccess.Repositories.EntityFrameworkRepository.Abstract;
using RentACar.DataAccess.Abstract;
using RentACar.DataAccess.Concrete.EntityFramework.DatabaseContext;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal : EfEntityRepositoryBase<Brand, RentACarDbContext>, IBrandDal
    {
        public EfBrandDal(RentACarDbContext context) : base(context)
        {
        }

    }
}
