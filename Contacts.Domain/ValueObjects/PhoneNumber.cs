using System.Text;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;
using Contacts.Domain.BaseTypes;

namespace Contacts.Domain.ValueObjects
{
    public partial class PhoneNumber : ValueObject
    {
        public const string numberRegex = @"^\+?[1-9][0-9]{7,14}$";
        public string Number { get; }
        public PhoneNumber(string number)
        {
            StringBuilder validationErrors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(number))
                validationErrors.Append($"{nameof(Number)} can't be null or white-spaced string");
            if (!PhoneNumberRegex().IsMatch(number))
                validationErrors.Append($"String \"{number}\" doesn't match the phone number template");

            if (validationErrors.Length > 0)
                throw new ValidationException(validationErrors.ToString());

            Number = number;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Number;
        }

        [GeneratedRegex(numberRegex)]
        private static partial Regex PhoneNumberRegex();
    }
}
