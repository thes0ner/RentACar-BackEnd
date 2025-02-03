using RentACar.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Abstract
{
    public interface ITransmissionService
    {
        Task<IEnumerable<TransmissionType>> GetTransmissionsAsync();
        Task<TransmissionType> GetSingleAsync(int id);
        Task AddAsync(TransmissionType transmissionType);
        Task UpdateAsync(TransmissionType transmissionType);
        Task DeleteAsync(TransmissionType transmissionType);
    }
}
