using RentACar.Business.Abstract;
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
using RentACar.Entities.DTO;
using AutoMapper;

namespace RentACar.Business.Concrete
{
    public class RentalManager : IRentalService
    {
        readonly IRentalDal _rentalDal;
        readonly IMapper _mapper;

        public RentalManager(IRentalDal rentalDal, IMapper mapper)
        {
            _rentalDal = rentalDal;
            _mapper = mapper;
        }

        public async Task<IResult> AddAsync(RentalDto rentalDto)
        {

            var rental = _mapper.Map<Rental>(rentalDto);

            await _rentalDal.AddAsync(rental);

            return new SuccessResult(Messages.RentalAdded);
        }

        public async Task<IResult> UpdateAsync(RentalDto rentalDto)
        {
            var rental = await _rentalDal.GetSingleAsync(p => p.Id == rentalDto.Id);

            if (rental == null)
            {
                return new ErrorResult(Messages.RentalNotFound);
            }

            _mapper.Map(rentalDto, rental);

            await _rentalDal.UpdateAsync(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public async Task<IResult> DeleteAsync(Rental rental)
        {
            await _rentalDal.DeleteAsync(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<IQueryable<Rental>> GetAllRentals()
        {
            var result = _rentalDal.GetAll();

            if (result == null)
            {
                return new ErrorDataResult<IQueryable<Rental>>(Messages.RentalNotFound);
            }

            return new SuccessDataResult<IQueryable<Rental>>(result, Messages.RentalsListed);
        }

        public async Task<IDataResult<Rental>> GetSingleAsync(int id)
        {
            var result = await _rentalDal.GetSingleAsync(p => p.Id == id);

            if (result == null)
            {
                return new ErrorDataResult<Rental>(Messages.RentalNotFound);
            }

            return new SuccessDataResult<Rental>(result, Messages.RentalsListed);
        }


    }
}
