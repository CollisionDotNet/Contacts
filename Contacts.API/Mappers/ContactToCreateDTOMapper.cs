using Contacts.Domain.Abstractions;

namespace Contacts.API.Mappers
{
    public class ContactToCreateDTOMapper : IMapper<Domain.Entities.Contact, API.DTOs.ContactToCreateDTO>
    {
        public Domain.Entities.Contact Map(API.DTOs.ContactToCreateDTO dto)
        {
            return new Domain.Entities.Contact
                (
                    Guid.NewGuid(),
                    dto.FirstName,
                    dto.LastName,
                    new Domain.ValueObjects.PhoneNumber(dto.PhoneNumber),
                    dto.EmailAddress == null ? null : new Domain.ValueObjects.Email(dto.EmailAddress),
                    dto.ImageUri == null ? null : new Domain.ValueObjects.Image(new Uri(dto.ImageUri))
                );
        }
        public API.DTOs.ContactToCreateDTO Map(Domain.Entities.Contact entity)
        {
            return new API.DTOs.ContactToCreateDTO
                (
                    entity.FirstName,
                    entity.LastName,
                    entity.PhoneNumber.Number,
                    entity.Email?.Address,
                    entity.Image?.Uri.ToString()
                );
        }
    }
}
