using System.Runtime.Serialization;

namespace Domain.Products.Exceptions
{
    [Serializable]
    internal class BarcodeLenghtException : Exception
    {
        public BarcodeLenghtException(string? message) : base(message)
        {
        }
    }
}