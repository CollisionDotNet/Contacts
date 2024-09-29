using Contacts.Domain.Entities;

namespace Contacts.Domain.Abstractions
{
    public interface IContactRepository
    {
        public Task<Guid> CreateAsync(Contact contact);
        public Task<Contact?> GetAsync(Guid id);
        public Task<IEnumerable<Contact>> GetAllAsync();
        public Task<Guid> UpdateAsync(Contact contact);
        public Task<Guid> DeleteAsync(Guid id);      
    }
}
