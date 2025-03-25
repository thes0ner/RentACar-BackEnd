using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Core.Utilities.Mapping
{

    public interface IMapper
    {
        IMapper Mapper { get; }
    }

}
