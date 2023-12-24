using Domain.Products.Exceptions;

namespace Domain.Products.ValueTypes
{
    public record Barcode
    {
        private const int DefaultLength = 12;
        private Barcode(string value) => Value = value;

        public string Value { get; init; }

        public static Barcode Create(string value)
        {
            //Guard
            if (string.IsNullOrEmpty(value))
                throw new EmptyValueException(
                    $"Provided Barcode Value is Empty"
                );

            if (value.Length != DefaultLength)
                throw new BarcodeLenghtException(
                    $"Provided Barcode must consist of {DefaultLength}Characters"
                    );

            //Create
            var barcode = value;

            //Validate

            return new Barcode(barcode);
        }
    }
}