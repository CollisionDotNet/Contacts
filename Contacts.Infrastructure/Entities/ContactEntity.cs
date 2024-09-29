namespace Contacts.Infrastructure.Entities
{
    public class ContactEntity
    {
        public const int firstNameMaxLength = 50;
        public const int lastNameMaxLength = 50;
        public const int emailMaxLength = 50;
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string? EmailAddress { get; set; }       
        public string? ImageUri { get; set; }
        public ContactEntity(Guid id, string firstName, string lastName, string phoneNumber, string? emailAddress, string? imageUri)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            EmailAddress = emailAddress;
            ImageUri = imageUri;
        }
    }
}
