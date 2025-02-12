using RentACar.Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Core.Utilities.Results.Concrete
{
    public class Result : IResult
    {


        // Constructor to initialize the Result with success status and a message.
        // - success: Indicates whether the operation was successful.
        // - message: Provides additional details about the result.
        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }


        // Constructor to initialize the Result with success status (no message).
        // - success: Indicates whether the operation was successful.
        public Result(bool success)
        {
            Success = success;
        }


        public bool Success { get; }
        public string Message { get; }
    }
}
