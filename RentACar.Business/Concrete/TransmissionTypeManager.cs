using RentACar.Business.Abstract;
using RentACar.Business.Constants;
using RentACar.Core.Entities.Concrete;
using RentACar.Core.Utilities.Results.Abstract;
using RentACar.Core.Utilities.Results.Concrete;
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

        public async Task<IResult> AddAsync(TransmissionType transmissionType)
        {
            await _transmissionTypeDal.AddAsync(transmissionType);
            return new SuccessResult(Messages.TransmissionTypeAdded);

        }

        public async Task<IResult> DeleteAsync(TransmissionType transmissionType)
        {
            await _transmissionTypeDal.DeleteAsync(transmissionType);
            return new SuccessResult(Messages.TransmissionTypeDeleted);
        }

        public async Task<IResult> UpdateAsync(TransmissionType transmissionType)
        {
            await _transmissionTypeDal.UpdateAsync(transmissionType);
            return new SuccessResult(Messages.TransmissionTypeUpdated);

        }

        public async Task<IDataResult<TransmissionType>> GetSingleAsync(int id)
        {
            var result = await _transmissionTypeDal.GetSingleAsync(p => p.Id == id);

            if (result == null)
            {
                return new ErrorDataResult<TransmissionType>(Messages.TransmissionTypeNotFound);
            }

            return new SuccessDataResult<TransmissionType>(result, Messages.TransmissionTypesListed);
        }

        public async Task<IDataResult<IEnumerable<TransmissionType>>> GetTransmissionsAsync()
        {
            var result = await _transmissionTypeDal.GetAllAsync();

            if (result == null)
            {
                return new ErrorDataResult<IEnumerable<TransmissionType>>(Messages.TransmissionTypeNotFound);
            }

            return new SuccessDataResult<IEnumerable<TransmissionType>>(result, Messages.TransmissionTypesListed);
        }


    }
}
