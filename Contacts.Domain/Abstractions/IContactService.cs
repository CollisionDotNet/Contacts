using Contacts.Domain.Entities;

namespace Contacts.Domain.Abstractions
{
    public interface IContactService
    {
        public Task<Guid> CreateContactAsync(Contact contact);
        public Task<Contact?> GetContactAsync(Guid id);
        public Task<IEnumerable<Contact>> GetAllContactsAsync();
        public Task<Guid> UpdateContactAsync(Contact contact);
        public Task<Guid> DeleteContactAsync(Guid id);
    }
}
