using RentACar.Business.Abstract;
using RentACar.DataAccess.Abstract;
using RentACar.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.Core.Utilities.Results.Abstract;
using RentACar.Core.Utilities.Results.Concrete;
using RentACar.Business.Constants;

namespace RentACar.Business.Concrete
{
    public class BrandManager : IBrandService
    {

        private readonly IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public async Task<IResult> AddAsync(Brand brand)
        {

            await _brandDal.AddAsync(brand);

            return new SuccessResult(Messages.BrandAdded);
        }

        public async Task<IResult> UpdateAsync(Brand brand)
        {
            await _brandDal.UpdateAsync(brand);

            return new SuccessResult(Messages.BrandUpdated);
        }

        public async Task<IResult> DeleteAsync(Brand brand)
        {
            await _brandDal.DeleteAsync(brand);

            return new SuccessResult(Messages.BrandDeleted);
        }


        public async Task<IDataResult<Brand>> GetSingleAsync(int id)
        {
            var result = await _brandDal.GetSingleAsync(p => p.Id == id);

            if (result is null)
            {
                return new ErrorDataResult<Brand>(Messages.BrandNotFound);
            }

            return new SuccessDataResult<Brand>(result);
        }

        public IDataResult<IQueryable<Brand>> GetAllBrands()
        {
            var result = _brandDal.GetAll();

            if (result is null || !result.Any())
            {
                return new ErrorDataResult<IQueryable<Brand>>(Messages.BrandNotFound);
            }

            return new SuccessDataResult<IQueryable<Brand>>(result);
        }

    }
}
