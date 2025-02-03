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

            if (brand.Name.Length < 5)
            {
                return new ErrorResult(Messages.BrandNameInvalid);
            }

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


        //Must be async -- Ned to be fixed
        public async Task<IDataResult<List<Brand>>> GetBrandsAsync()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAllAsync(), Messages.BrandListed);
        }

        public Task<IDataResult<Brand>> GetSingleAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
