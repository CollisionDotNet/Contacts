namespace Contacts.API.DTOs
{
    public record ContactToCreateDTO(
        string FirstName,
        string LastName,
        string PhoneNumber,
        string? EmailAddress,
        string? ImageUri);
}
