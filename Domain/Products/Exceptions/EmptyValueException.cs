using System.Runtime.Serialization;

namespace Domain.Products.Exceptions
{
    [Serializable]
    internal class EmptyValueException : Exception
    {
        public EmptyValueException()
        {
        }

        public EmptyValueException(string? message) : base(message)
        {
        }
    }
}