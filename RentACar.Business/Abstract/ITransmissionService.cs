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
        Task<IDataResult<IEnumerable<TransmissionType>>> GetTransmissionsAsync();
        Task<IDataResult<TransmissionType>> GetSingleAsync(int id);
        Task<IResult> AddAsync(TransmissionType transmissionType);
        Task<IResult> UpdateAsync(TransmissionType transmissionType);
        Task<IResult> DeleteAsync(TransmissionType transmissionType);
    }
}
