using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainfall.API.Common.CustomExceptions
{
    public class NullValueException : Exception
    {
        public NullValueException() : base() { }
        public NullValueException(string message) : base(message) { }
        public NullValueException(string message, Exception inner) : base(message, inner) { }
    }
}
