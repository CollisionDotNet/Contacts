namespace Contacts.Infrastructure.Entities
{
    public class ContactEntity
    {
        public const int firstNameMaxLength = 50;
        public const int lastNameMaxLength = 50;
        public const int emailMaxLength = 50;
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }       
        public string? ImageUri { get; set; }
        public ContactEntity(int id, string firstName, string lastName, string phoneNumber, string? email, string? imageUri)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            PhoneNumber = phoneNumber;
            Email = email;
            ImageUri = imageUri;
        }
    }
}
