using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.API.Core.Exceptions
{
    public class ApiApplicationException : ApplicationException
    {
        public ApiApplicationException() : base() { }
        public ApiApplicationException(string message) : base(message) { }
        public ApiApplicationException(string message, Exception innerException) : base(message, innerException) { }
    }
}
