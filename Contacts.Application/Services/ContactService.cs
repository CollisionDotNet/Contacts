using Contacts.Domain.Abstractions;
using Contacts.Domain.Entities;

namespace Contacts.Application.Services
{
    public class ContactService : IContactService
    {
        private IContactRepository _contactRepository;
        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<int> CreateContactAsync(Contact contact)
        {
            return await _contactRepository.CreateAsync(contact);
        }
        public async Task<Contact> GetContactAsync(int id)
        {
            return await _contactRepository.GetAsync(id);
        }
        public async Task<IEnumerable<Contact>> GetAllContactsAsync()
        {
            return await _contactRepository.GetAllAsync();
        }
        public async Task<int> UpdateContactAsync(int id, Contact contact)
        {
            return await _contactRepository.UpdateAsync(id, contact);
        }

        public async Task<int> DeleteContactAsync(int id)
        {
            return await _contactRepository.DeleteAsync(id);
        }                 
    }
}
