using RentACar.Business.Abstract;
using RentACar.Core.Entities.Concrete;
using RentACar.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Concrete
{
    public class TransmissionTypeManager : ITransmissionService
    {
        private readonly ITransmissionTypeDal _transmissionTypeDal;

        public TransmissionTypeManager(ITransmissionTypeDal transmissionTypeDal)
        {
            _transmissionTypeDal = transmissionTypeDal;
        }

        public async Task AddAsync(TransmissionType transmissionType)
        {
            await _transmissionTypeDal.AddAsync(transmissionType);
        }

        public async Task DeleteAsync(TransmissionType transmissionType)
        {
            await _transmissionTypeDal.DeleteAsync(transmissionType);
        }

        public async Task UpdateAsync(TransmissionType transmissionType)
        {
            await _transmissionTypeDal.UpdateAsync(transmissionType);
        }

        public async Task<IEnumerable<TransmissionType>> GetTransmissionsAsync()
        {
            return await _transmissionTypeDal.GetAllAsync();
        }

        public async Task<TransmissionType> GetSingleAsync(int id)
        {
            return await _transmissionTypeDal.GetSingleAsync(c => c.Id == id);
        }




    }
}
