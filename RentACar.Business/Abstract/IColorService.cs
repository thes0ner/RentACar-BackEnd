using RentACar.Core.Entities.Concrete;
using RentACar.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Abstract
{
    public interface IColorService
    {
        Task<IDataResult<IEnumerable<Color>>> GetColorsAsync();
        Task<IDataResult<Color>> GetSingleAsync(int id);
        Task<IResult> AddAsync(Color color);
        Task<IResult> UpdateAsync(Color color);
        Task<IResult> DeleteAsync(Color color);

    }
}
