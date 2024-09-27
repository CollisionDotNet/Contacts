using Contacts.Domain.Abstractions;
using Contacts.Domain.Entities;
using Contacts.Infrastructure.Entities;
using Contacts.Infrastructure.Mappers;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Infrastructure.Repositories
{
    public class EFContactRepository : IContactRepository
    {
        private readonly ContactsDbContext _context;
        private readonly IMapper<Contact, ContactEntity> _mapper;
        public EFContactRepository(ContactsDbContext context, IMapper<Contact, ContactEntity> mapper)
        {
            _context = context; 
            _mapper = mapper;
        }
        public async Task<int> CreateAsync(Contact contact)
        {
            ContactEntity toAdd = _mapper.ToInfrastructureEntity(contact);
            await _context.Contacts.AddAsync(toAdd);
            await _context.SaveChangesAsync();
            return toAdd.Id;
        }
        public async Task<Contact?> GetAsync(int id)
        {
            ContactEntity? contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return null;
            }
            else
            {
                return _mapper.ToDomainEntity(contact);
            }
        }
        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            IEnumerable<ContactEntity> contacts = await _context.Contacts.AsNoTracking().ToListAsync();
            return contacts.Select(_mapper.ToDomainEntity);
        }
        public async Task<int> UpdateAsync(Contact contact)
        {
            ContactEntity toUpdate = _mapper.ToInfrastructureEntity(contact);
            _context.Contacts.Update(toUpdate);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> DeleteAsync(int id)
        {
            await _context.Contacts.Where(c => c.Id == id).ExecuteDeleteAsync();
            return id;
        }                       
    }
}
