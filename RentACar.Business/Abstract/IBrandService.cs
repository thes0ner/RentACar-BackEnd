using RentACar.Core.Entities.Concrete;
using RentACar.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Abstract
{
    public interface IBrandService
    {

        Task<IDataResult<IEnumerable<Brand>>> GetBrandsAsync();
        Task<IDataResult<Brand>> GetSingleAsync(int id);
        Task<IResult> AddAsync(Brand brand);
        Task<IResult> UpdateAsync(Brand brand);
        Task<IResult> DeleteAsync(Brand brand);

    }
}
