using Contacts.Domain.BaseTypes;
using Contacts.Domain.ValueObjects;
using Contacts.Domain.Exceptions;
using System.Text;

namespace Contacts.Domain.Entities
{
    public class Contact : IEntity
    {
        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public PhoneNumber PhoneNumber { get; }
        public Email? Email { get; }       
        public Image? Image { get; }
        public Contact(Guid id, string firstName, string lastName, PhoneNumber phoneNumber, Email? email, Image? image)
        {
            StringBuilder validationErrors = new StringBuilder();

            if (string.IsNullOrWhiteSpace(firstName))
                validationErrors.Append($"{nameof(FirstName)} can't be null or white-spaced string");

            if (string.IsNullOrWhiteSpace(lastName))
                validationErrors.Append($"{nameof(LastName)} can't be null or white-spaced string");

            if (phoneNumber == null)
                validationErrors.Append($"{nameof(PhoneNumber)} can't be null");

            if (validationErrors.Length > 0)
                throw new ValidationException(validationErrors.ToString());

            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber!;
            Email = email;            
            Image = image;
        }
    }
}
