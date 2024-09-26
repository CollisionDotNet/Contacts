using Contacts.Domain.Entities;

namespace Contacts.Domain.Abstractions
{
    public interface IContactService
    {
        public Task<int> CreateContactAsync(Contact contact);
        public Task<Contact> GetContactAsync(int id);
        public Task<IEnumerable<Contact>> GetAllContactsAsync();
        public Task<int> UpdateContactAsync(int id, Contact contact);
        public Task<int> DeleteContactAsync(int id);

    }
}
