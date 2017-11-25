using System;

namespace Skycop.Common.Exceptions
{
    public class APIKeyException : Exception
    {
        public APIKeyException(string message) : base(message) { }
    }

    public class APIVersionException : Exception
    {
        public APIVersionException(string message) : base(message) { }
    }

    public class AuthenticationException : Exception
    {
        public AuthenticationException(string message) : base(message) { }
    }

    public class KeyNotFoundInCacheException : Exception
    {
        public KeyNotFoundInCacheException(string message) : base(message) { }
    }

    public class DataNotFoundException : Exception
    {
        public DataNotFoundException(string message) : base(message) { }
    }

    public class DataIsNotSavedException : Exception
    {
        public DataIsNotSavedException(string message) : base(message) { }
    }

    public class DataIsNotDeletedException : Exception
    {
        public DataIsNotDeletedException(string message) : base(message) { }
    }

    public class InternalException : Exception
    {
        public InternalException(string message) : base(message) { }
    }
}
