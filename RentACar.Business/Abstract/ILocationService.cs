using RentACar.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Abstract
{
    public interface ILocationService
    {
        Task<IEnumerable<Location>> GetLocationsAsync();
        Task<Location> GetSingleAsync(int id);
        Task AddAsync(Location location);
        Task UpdateAsync(Location location);
        Task DeleteAsync(Location location);
    }
}
