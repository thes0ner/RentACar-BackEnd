using RentACar.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Core.Utilities.Results.Concrete
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        // Represents the data payload of the result.
        public T Data { get; }


        // Constructor to initialize the DataResult with data, success status, and a message.
        // - data: The data payload to be returned.
        // - success: Indicates whether the operation was successful.
        // - message: Provides additional details about the result.
        public DataResult(T data, bool success, string message) : base(success, message)
        {
            Data = data;
        }


        // Constructor to initialize the DataResult with data and success status (no message).
        // - data: The data payload to be returned.
        // - success: Indicates whether the operation was successful.
        public DataResult(T data, bool success) : base(success)
        {
            Data = data;
        }

    }
}
