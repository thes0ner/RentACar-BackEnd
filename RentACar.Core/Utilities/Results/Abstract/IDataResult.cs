using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Core.Utilities.Results.Abstract
{
    public interface IDataResult<T> : IResult
    {

        // Represents the data payload of the result.
        // This property holds the actual data returned by the operation.
        T Data { get; }
    }
}
