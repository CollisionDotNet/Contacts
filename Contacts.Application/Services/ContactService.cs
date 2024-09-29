using Contacts.Domain.Abstractions;
using Contacts.Domain.Entities;

namespace Contacts.Application.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;
        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }
        public async Task<Guid> CreateContactAsync(Contact contact)
        {
            return await _contactRepository.CreateAsync(contact);
        }
        public async Task<Contact?> GetContactAsync(Guid id)
        {
            return await _contactRepository.GetAsync(id);
        }
        public async Task<IEnumerable<Contact>> GetAllContactsAsync()
        {
            return await _contactRepository.GetAllAsync();
        }
        public async Task<Guid> UpdateContactAsync(Contact contact)
        {
            return await _contactRepository.UpdateAsync(contact);
        }
        public async Task<Guid> DeleteContactAsync(Guid id)
        {
            return await _contactRepository.DeleteAsync(id);
        }                 
    }
}
