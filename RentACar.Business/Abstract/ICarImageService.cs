using RentACar.Core.Utilities.Results.Abstract;
using RentACar.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Abstract
{
    public interface ICarImageService
    {
        Task<IResult> AddAsync(CarImage carImage);
        Task<IResult> UpdateAsync(CarImage carImage);
        Task<IResult> DeleteAsync(CarImage carImage);

        // Queries
        IDataResult<IQueryable<CarImage>> GetAllCarImages();
        Task<IDataResult<CarImage>> GetSingleAsync(int id);
    }
}
