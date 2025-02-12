using RentACar.Core.Entities.Concrete;
using RentACar.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Abstract
{
    public interface ITransmissionService
    {
        IDataResult<IQueryable<Transmission>> GetAllTransmissions();
        Task<IDataResult<Transmission>> GetSingleAsync(int id);
        Task<IResult> AddAsync(Transmission transmission);
        Task<IResult> UpdateAsync(Transmission transmission);
        Task<IResult> DeleteAsync(Transmission transmission);
    }
}
