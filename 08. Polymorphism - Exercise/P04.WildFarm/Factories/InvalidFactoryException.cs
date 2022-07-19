using System;
using System.Runtime.Serialization;

namespace WildFarm.Factories
{
    [Serializable]
    internal class InvalidFactoryException : System.Exception
    {
        public InvalidFactoryException()
        {
        }

        public InvalidFactoryException(string message) : base(message)
        {
        }

        public InvalidFactoryException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidFactoryException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}