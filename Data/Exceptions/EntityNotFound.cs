using System.Runtime.Serialization;

namespace Data.Exceptions
{
    [Serializable]
    internal class EntityNotFound : Exception
    {
        public EntityNotFound()
        {
        }

        public EntityNotFound(string? message) : base(message)
        {
        }

        public EntityNotFound(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected EntityNotFound(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}