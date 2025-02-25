using RentACar.Business.Abstract;
using RentACar.Business.Constants;
using RentACar.Core.Utilities.Results.Abstract;
using RentACar.Core.Utilities.Results.Concrete;
using RentACar.DataAccess.Abstract;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        readonly ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        public async Task<IResult> AddAsync(CarImage carImage)
        {
            await _carImageDal.AddAsync(carImage);
            return new SuccessResult();
        }

        public async Task<IResult> UpdateAsync(CarImage carImage)
        {
            await _carImageDal.UpdateAsync(carImage);
            return new SuccessResult();
        }

        public async Task<IResult> DeleteAsync(CarImage carImage)
        {
            await _carImageDal.DeleteAsync(carImage);
            return new SuccessResult();
        }

        public IDataResult<IQueryable<CarImage>> GetAllCarImages()
        {
            var result = _carImageDal.GetAll();

            if (result == null || !result.Any())
            {
                return new ErrorDataResult<IQueryable<CarImage>>(Messages.CarImageNotFound);
            }

            return new SuccessDataResult<IQueryable<CarImage>>(result, Messages.CarImagesListed);

        }

        public async Task<IDataResult<CarImage>> GetSingleAsync(int id)
        {
            var result = await _carImageDal.GetSingleAsync(x => x.Id == id);

            if (result == null)
            {
                return new ErrorDataResult<CarImage>(Messages.CarImageNotFound);
            }

            return new SuccessDataResult<CarImage>(result, Messages.CarImagesListed);
        }


    }
}
