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

        public async Task<IEnumerable<Brand>> GetBrandsAsync()
        {
            return await _brandDal.GetAllAsync();
        }

        public async Task<Brand> GetSingleAsync(int id)
        {
            return await _brandDal.GetSingleAsync(b => b.Id == id);
        }

        public async Task AddAsync(Brand brand)
        {
            await _brandDal.AddAsync(brand);
        }

        public async Task UpdateAsync(Brand brand)
        {
            await _brandDal.UpdateAsync(brand);
        }

        public async Task DeleteAsync(Brand brand)
        {
            var brandToDelete = await _brandDal.GetSingleAsync(c=> c.Id == brand.Id);
            await _brandDal.DeleteAsync(brand);
        }
    }
}
