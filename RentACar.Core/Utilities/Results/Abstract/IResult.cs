using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Core.Utilities.Results.Abstract
{
    public interface IResult
    {

        // Indicates whether the operation was successful.
        bool Success { get; }

        // Provides a message describing the result of the operation.
        // - This can include success messages, error messages, or other relevant information.
        string Message { get; }
    }
}
