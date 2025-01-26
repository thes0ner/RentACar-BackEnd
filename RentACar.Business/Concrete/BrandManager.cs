using RentACar.Business.Abstract;
using RentACar.DataAccess.Abstract;
using RentACar.Core.Entities.Concrete;
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

        public async Task Add(Brand brand)
        {
            await _brandDal.AddAsync(brand);
        }

        public Task<IEnumerable<Brand>> GetAll()
        {
            return _brandDal.GetAllAsync();
        }
    }
}
