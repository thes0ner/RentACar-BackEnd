using RentACar.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Abstract
{
    public interface IColorService
    {
        Task<IEnumerable<Color>> GetAll();
        Task<Color> GetSingleAsync(int id);
        Task AddAsync(Color color);
        Task UpdateAsync(Color color);
        Task DeleteAsync(Color color);

    }
}
