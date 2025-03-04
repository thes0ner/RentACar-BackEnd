﻿using RentACar.Business.Abstract;
using RentACar.Business.Constants;
using RentACar.Entities.Concrete;
using RentACar.Core.Utilities.Results.Abstract;
using RentACar.Core.Utilities.Results.Concrete;
using RentACar.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentACar.DataAccess.Concrete.EntityFramework;

namespace RentACar.Business.Concrete
{
    public class TransmissionManager : ITransmissionService
    {
        private readonly ITransmissionDal _transmissionDal;

        public TransmissionManager(ITransmissionDal transmissionDal)
        {
            _transmissionDal = transmissionDal;
        }

        public async Task<IResult> AddAsync(Transmission transmission)
        {
            var result = await CheckIfTransmissionTypeExist(transmission.Type);
            if (result != null)
            {
                return new ErrorResult(Messages.TransmissionAlreadyExists);
            }

            await _transmissionDal.AddAsync(transmission);
            return new SuccessResult(Messages.TransmissionAdded);

        }

        public async Task<IResult> DeleteAsync(Transmission transmission)
        {
            await _transmissionDal.DeleteAsync(transmission);
            return new SuccessResult(Messages.TransmissionDeleted);
        }

        public async Task<IResult> UpdateAsync(Transmission transmission)
        {
            await _transmissionDal.UpdateAsync(transmission);
            return new SuccessResult(Messages.TransmissionUpdated);

        }

        public async Task<IDataResult<Transmission>> GetSingleAsync(int id)
        {
            var result = await _transmissionDal.GetSingleAsync(p => p.Id == id);

            if (result == null)
            {
                return new ErrorDataResult<Transmission>(Messages.TransmissionNotFound);
            }

            return new SuccessDataResult<Transmission>(result, Messages.TransmissionsListed);
        }

        public IDataResult<IQueryable<Transmission>> GetAllTransmissions()
        {
            var result = _transmissionDal.GetAll();

            if (result == null)
            {
                return new ErrorDataResult<IQueryable<Transmission>>(Messages.TransmissionNotFound);
            }

            return new SuccessDataResult<IQueryable<Transmission>>(result, Messages.TransmissionsListed);
        }

        private async Task<IResult> CheckIfTransmissionTypeExist(string typeName)
        {
            var trimmedName = typeName.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(trimmedName))
            {
                return new ErrorResult(Messages.TransmissionInvalid);
            }

            var existingTransmission = await _transmissionDal.GetSingleAsync(p => p.Type.Trim().ToLower() == trimmedName);

            if (existingTransmission != null)
            {
                return new ErrorResult(Messages.TransmissionAlreadyExists);
            }

            return null;
        }
    }
}
