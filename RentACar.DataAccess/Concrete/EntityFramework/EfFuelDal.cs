using RentACar.Core.DataAccess.Repositories.EntityFrameworkRepository.Abstract;
using RentACar.Entities.Concrete;
using RentACar.DataAccess.Abstract;
using RentACar.DataAccess.Concrete.EntityFramework.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DataAccess.Concrete.EntityFramework
{
    public class EfFuelDal : EfEntityRepositoryBase<Fuel, RentACarDbContext>, IFuelDal
    {
        public EfFuelDal(RentACarDbContext context) : base(context)
        {
        }
    }
}
