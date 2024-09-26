using Contacts.Domain.Exceptions;
using System.Text;
using System.Text.RegularExpressions;

namespace Contacts.Domain.ValueObjects
{
    public class Email : ValueObject
    {
        public const int addressMaxLength = 50;
        public const string addressRegex = @"[a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+\.[a-zA-Z0-9_-]+";
        public string Address { get; }
        public Email(string address) 
        {
            StringBuilder validationErrors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(address))
                validationErrors.Append($"{nameof(Address)} can't be null or white-spaced string");
            if (address.Length > addressMaxLength)
                validationErrors.Append($"{nameof(Address)} can't be longer than {addressMaxLength}");
            if (!Regex.IsMatch(address, addressRegex))
                validationErrors.Append($"String \"{address}\" doesn't match the email address template");

            if(validationErrors.Length > 0) 
                throw new ValidationException(validationErrors.ToString());

            Address = address;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Address;
        }
    }
}
