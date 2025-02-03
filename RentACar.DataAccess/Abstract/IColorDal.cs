using RentACar.Core.DataAccess.Repositories.EntityFrameworkRepository.Abstract;
using RentACar.Core.Entities.Concrete;
using RentACar.DataAccess.Concrete.EntityFramework.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DataAccess.Abstract
{
    public interface IColorDal :  IEntityRepository<Color>
    {

    }
}
