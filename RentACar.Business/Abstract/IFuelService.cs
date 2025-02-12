using RentACar.Core.Entities.Concrete;
using RentACar.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Abstract
{
    public interface IFuelService
    {
        IDataResult<IQueryable<Fuel>> GetAllFuels();
        Task<IDataResult<Fuel>> GetSingleAsync(int id);
        Task<IResult> AddAsync(Fuel fuel);
        Task<IResult> UpdateAsync(Fuel fuel);
        Task<IResult> DeleteAsync(Fuel fuel);
    }
}
