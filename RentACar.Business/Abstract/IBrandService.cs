using RentACar.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Abstract
{
    public interface IBrandService
    {
        Task<IEnumerable<Brand>> GetBrandsAsync();
        Task<Brand> GetSingleAsync(int id);
        Task AddAsync(Brand brand);
        Task UpdateAsync(Brand brand);
        Task DeleteAsync(Brand brand);

    }
}
