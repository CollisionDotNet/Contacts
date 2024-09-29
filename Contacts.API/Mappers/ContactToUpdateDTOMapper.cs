using Contacts.Domain.Abstractions;

namespace Contacts.API.Mappers
{
    public class ContactToUpdateDTOMapper : IMapper<Domain.Entities.Contact, API.DTOs.ContactToUpdateDTO>
    {
        public Domain.Entities.Contact Map(API.DTOs.ContactToUpdateDTO dto)
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
        public API.DTOs.ContactToUpdateDTO Map(Domain.Entities.Contact entity)
        {
            return new API.DTOs.ContactToUpdateDTO
                (
                    entity.Id,
                    entity.FirstName,
                    entity.LastName,
                    entity.PhoneNumber.Number,
                    entity.Email?.Address,
                    entity.Image?.Uri.ToString()
                );
        }
    }
}
