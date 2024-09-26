using Contacts.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Contacts.Domain.Entities
{
    public class Contact
    {
        public const int firstNameMaxLength = 50;
        public const int lastNameMaxLength = 50;
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public PhoneNumber PhoneNumber { get; }
        public Email? Email { get; }       
        public Image? Image { get; }
        public Contact(int id, string firstName, string lastName, PhoneNumber phoneNumber, Email? email, Image? image)
        {
            StringBuilder validationErrors = new StringBuilder();
            if (string.IsNullOrWhiteSpace(firstName))
                validationErrors.Append($"{nameof(FirstName)} can't be null or white-spaced string");
            if (firstName.Length > firstNameMaxLength)
                validationErrors.Append($"{nameof(FirstName)} can't be longer than {firstNameMaxLength}");

            if (string.IsNullOrWhiteSpace(lastName))
                validationErrors.Append($"{nameof(LastName)} can't be null or white-spaced string");
            if (lastName.Length > lastNameMaxLength)
                validationErrors.Append($"{nameof(LastName)} can't be longer than {lastNameMaxLength}");

            if (phoneNumber == null)
                validationErrors.Append($"{nameof(PhoneNumber)} can't be null");

            if (validationErrors.Length > 0)
                throw new ValidationException(validationErrors.ToString());

            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber!;
            Image = image;
        }
    }
}
