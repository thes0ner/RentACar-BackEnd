using RentACar.Business.Abstract;
using RentACar.DataAccess.Abstract;
using RentACar.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Concrete
{
    public class CarManager : ICarService
    {
        private readonly ICarDal _carDal;

        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public Task AddCar(Car car)
        {
            _carDal.AddAsync(car);

            return Task.CompletedTask;
        }

        public Task<IEnumerable<Car>> GetAll()
        {
            return _carDal.GetAllAsync();
        }

    }
}
