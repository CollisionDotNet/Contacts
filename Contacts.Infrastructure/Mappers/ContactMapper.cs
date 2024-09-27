namespace Contacts.Infrastructure.Mappers
{
    public class ContactMapper : IMapper<Domain.Entities.Contact, Infrastructure.Entities.ContactEntity>
    {
        public Domain.Entities.Contact ToDomainEntity(Infrastructure.Entities.ContactEntity entity)
        {
            return new Domain.Entities.Contact
                (
                    entity.Id, 
                    entity.FirstName,
                    entity.LastName,
                    new Domain.ValueObjects.PhoneNumber(entity.PhoneNumber),
                    entity.Email == null ? null : new Domain.ValueObjects.Email(entity.Email),
                    entity.ImageUri == null ? null : new Domain.ValueObjects.Image(new Uri(entity.ImageUri))
                );
        }
        public Infrastructure.Entities.ContactEntity ToInfrastructureEntity(Domain.Entities.Contact entity)
        {
            return new Infrastructure.Entities.ContactEntity
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
