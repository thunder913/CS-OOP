using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace CustomException
{
    class NameException : Exception
    {
        public NameException()
        {
        }

        public NameException(string message) : base(message)
        {
        }

        public NameException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NameException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
