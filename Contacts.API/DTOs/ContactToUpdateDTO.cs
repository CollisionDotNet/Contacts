namespace Contacts.API.DTOs
{
    public record ContactToUpdateDTO(
        Guid Id,
        string FirstName,
        string LastName,
        string PhoneNumber,
        string? EmailAddress,
        string? ImageUri);
}
