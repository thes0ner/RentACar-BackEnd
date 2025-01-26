using RentACar.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Abstract
{
    public interface ICarService
    {
        Task<IEnumerable<Car>> GetAll();
        Task AddCar(Car car);
    }
}
