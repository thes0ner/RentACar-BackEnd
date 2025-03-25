using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Core.Utilities.Mapping
{
    public class MapperService : IMapper
    {
        public IMapper Mapper { get; }

        public MapperService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(Assembly.GetExecutingAssembly());
            });

            Mapper = (IMapper?)config.CreateMapper();
        }
    }

}
