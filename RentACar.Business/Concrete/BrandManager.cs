using RentACar.Business.Abstract;
using RentACar.DataAccess.Abstract;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Concrete
{
    public class BrandManager : IBrandService
    {

        private readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public Task Add(Brand brand)
        {
            _brandDal.AddAsync(brand);

            return Task.CompletedTask;
        }

        public Task<IEnumerable<Brand>> GetAll()
        {
            return _brandDal.GetAllAsync();
        }
    }
}
