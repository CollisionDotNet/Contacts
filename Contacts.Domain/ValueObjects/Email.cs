using Contacts.Domain.Exceptions;
using System.Text;
using System.Text.RegularExpressions;

namespace Contacts.Domain.ValueObjects
{
    public partial class Email : ValueObject
    {
        public const string addressRegex = @"[a-zA-Z0-9._-]+@[a-zA-Z0-9._-]+\.[a-zA-Z0-9_-]+";
        public string Address { get; }
        public Email(string address) 
        {
            StringBuilder validationErrors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(address))
                validationErrors.Append($"{nameof(Address)} can't be null or white-spaced string");
            if (!EmailAddressRegex().IsMatch(address))
                validationErrors.Append($"String \"{address}\" doesn't match the email address template");

            if(validationErrors.Length > 0) 
                throw new ValidationException(validationErrors.ToString());

            Address = address;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Address;
        }

        [GeneratedRegex(addressRegex)]
        private static partial Regex EmailAddressRegex();
    }
}
