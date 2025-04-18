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
    public class VehicleManager : IVehicleService
    {
        private readonly IVehicleDal _vehicleDal;

        public VehicleManager(IVehicleDal vehicleDal)
        {
            _vehicleDal = vehicleDal;
        }

        public async Task<IResult> AddAsync(Vehicle vehicle)
        {
            var result = await CheckIfVehicleTypeExist(vehicle.Type);
            if (result != null)
            {
                return new ErrorResult(Messages.VehicleAlreadyExists);
            }


            await _vehicleDal.AddAsync(vehicle);
            return new SuccessResult(Messages.VehicleAdded);
        }

        public async Task<IResult> DeleteAsync(Vehicle vehicle)
        {
            await _vehicleDal.DeleteAsync(vehicle);
            return new SuccessResult(Messages.VehicleDeleted);

        }

        public async Task<IResult> UpdateAsync(Vehicle vehicleType)
        {
            await _vehicleDal.UpdateAsync(vehicleType);
            return new SuccessResult(Messages.VehicleUpdated);
        }

        public async Task<IDataResult<Vehicle>> GetSingleAsync(int id)
        {
            var result = await _vehicleDal.GetSingleAsync(p => p.Id == id);

            if (result == null)
            {
                return new ErrorDataResult<Vehicle>(Messages.VehicleNotFound);
            }

            return new SuccessDataResult<Vehicle>(result, Messages.VehiclesListed);
        }

        public IDataResult<IQueryable<Vehicle>> GetAllVehicles()
        {
            var result = _vehicleDal.GetAll();

            if (result == null || !result.Any())
            {
                return new ErrorDataResult<IQueryable<Vehicle>>(Messages.VehicleNotFound);
            }

            return new SuccessDataResult<IQueryable<Vehicle>>(result, Messages.VehiclesListed);
        }

        private async Task<IResult> CheckIfVehicleTypeExist(string typeName)
        {
            var trimmedName = typeName.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(trimmedName))
            {
                return new ErrorResult(Messages.VehicleInvalid);
            }

            var existingTransmission = await _vehicleDal.GetSingleAsync(p => p.Type.Trim().ToLower() == trimmedName);

            if (existingTransmission != null)
            {
                return new ErrorResult(Messages.VehicleAlreadyExists);
            }

            return null;
        }


    }
}
