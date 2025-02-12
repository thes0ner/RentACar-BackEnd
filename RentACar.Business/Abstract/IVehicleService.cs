using RentACar.Core.Entities.Concrete;
using RentACar.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Abstract
{
    public interface IVehicleService
    {
        IDataResult<IQueryable<Vehicle>> GetAllVehicles();
        Task<IDataResult<Vehicle>> GetSingleAsync(int id);
        Task<IResult> AddAsync(Vehicle vehicle);
        Task<IResult> UpdateAsync(Vehicle vehicle);
        Task<IResult> DeleteAsync(Vehicle vehicle);
    }
}
