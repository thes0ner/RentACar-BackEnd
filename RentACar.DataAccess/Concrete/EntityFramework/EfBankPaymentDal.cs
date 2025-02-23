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
    public class EfBankPaymentDal : EfEntityRepositoryBase<Bank, RentACarDbContext>, IBankPaymentDal
    {
        public EfBankPaymentDal(RentACarDbContext context) : base(context)
        {

        }
    }
}
