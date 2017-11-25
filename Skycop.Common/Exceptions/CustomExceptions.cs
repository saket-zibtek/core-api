using System;

namespace Skycop.Common.Exceptions
{
    public class DALException : Exception
    {
        public DALException() { }
        public DALException(string message) : base(message) { }
        public DALException(string message, Exception innerException) : base(message, innerException) { }
    }

    public class BALException : Exception
    {
        public BALException() { }
        public BALException(string message) : base(message) { }
        public BALException(string message, Exception innerException) : base(message, innerException) { }
    }
}
