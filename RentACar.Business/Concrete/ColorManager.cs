using RentACar.Business.Abstract;
using RentACar.Business.Constants;
using RentACar.Core.Entities.Concrete;
using RentACar.Core.Utilities.Results.Abstract;
using RentACar.Core.Utilities.Results.Concrete;
using RentACar.DataAccess.Abstract;
using RentACar.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Concrete
{
    public class ColorManager : IColorService
    {
        private readonly IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public async Task<IResult> AddAsync(Color color)
        {
            await _colorDal.AddAsync(color);

            return new SuccessResult(Messages.ColorAdded);
        }

        public async Task<IResult> DeleteAsync(Color color)
        {
            await _colorDal.DeleteAsync(color);

            return new SuccessResult(Messages.ColorDeleted);
        }

        public async Task<IResult> UpdateAsync(Color color)
        {
            await _colorDal.UpdateAsync(color);

            return new SuccessResult(Messages.ColorUpdated);
        }


        public async Task<IDataResult<Color>> GetSingleAsync(int id)
        {
            var result = await _colorDal.GetSingleAsync(p => p.Id == id);

            if (result == null)
            {
                return new ErrorDataResult<Color>(Messages.ColorNotFound);
            }

            return new SuccessDataResult<Color>(result, Messages.ColorsListed);
        }

        public IDataResult<IQueryable<Brand>> GetAllColors()
        {
            throw new NotImplementedException();
        }

        public IDataResult<IQueryable<Brand>> GetFilteredBrandsById(int id)
        {
            throw new NotImplementedException();
        }

        public IDataResult<IQueryable<Brand>> GetFilteredBrandsByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
