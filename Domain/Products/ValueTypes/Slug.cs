using Domain.Products.Exceptions;

namespace Domain.Products.ValueTypes
{
    public record Slug
    {
        private Slug(string value) => Value = value;

        public string Value { get; init; }

        public static Slug Create(string value)
        {
            //Guard
            if (string.IsNullOrEmpty(value))
                throw new EmptyValueException(
                    $"Provided Value is Empty"
                );

            //Create
            var slug = value.Replace(" ", "-").ToLower();

            //Validate
            if (slug[0] == '-')
                slug.Remove(0);

            if (slug[slug.Length - 1] == '-')
                slug.Remove(slug.Length - 1);

            return new Slug(slug);
        }
    }
}