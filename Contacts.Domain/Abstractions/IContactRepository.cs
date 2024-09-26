using Contacts.Domain.Entities;

namespace Contacts.Domain.Abstractions
{
    public interface IContactRepository
    {
        public Task<int> CreateAsync(Contact contact);
        public Task<Contact> GetAsync(int id);
        public Task<IEnumerable<Contact>> GetAllAsync();
        public Task<int> UpdateAsync(int id, Contact contact);
        public Task<int> DeleteAsync(int id);      
    }
}
