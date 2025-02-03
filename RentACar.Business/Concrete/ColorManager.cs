using RentACar.Business.Abstract;
using RentACar.Core.Entities.Concrete;
using RentACar.DataAccess.Abstract;
using RentACar.DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Business.Concrete
{
    public class ColorManager : IColorService
    {
        private readonly IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

        public async Task AddAsync(Color color)
        {
            await _colorDal.AddAsync(color);
        }

        public async Task DeleteAsync(Color color)
        {
            await _colorDal.DeleteAsync(color);
        }

        public async Task UpdateAsync(Color color)
        {
            await _colorDal.UpdateAsync(color);
        }

        public async Task<IEnumerable<Color>> GetColorsAsync()
        {
            return await _colorDal.GetAllAsync();
        }

        public async Task<Color> GetSingleAsync(int id)
        {
            return await _colorDal.GetSingleAsync(c => c.Id == id);
        }
    }
}
