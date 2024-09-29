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
        public async Task<Guid> CreateAsync(Contact contact)
        {
            ContactEntity toAdd = _mapper.Map(contact);
            await _context.Contacts.AddAsync(toAdd);
            await _context.SaveChangesAsync();
            return toAdd.Id;
        }
        public async Task<Contact?> GetAsync(Guid id)
        {
            ContactEntity? contact = await _context.Contacts.FindAsync(id);
            if (contact == null)
            {
                return null;
            }
            else
            {
                return _mapper.Map(contact);
            }
        }
        public async Task<IEnumerable<Contact>> GetAllAsync()
        {            
            return await _context.Contacts.AsNoTracking().Select(c => _mapper.Map(c)).ToListAsync();
        }
        public async Task<Guid> UpdateAsync(Contact contact)
        {
            ContactEntity toUpdate = _mapper.Map(contact);
            _context.Contacts.Update(toUpdate);
            await _context.SaveChangesAsync();
            return toUpdate.Id;
        }
        public async Task<Guid> DeleteAsync(Guid id)
        {
            await _context.Contacts.Where(c => c.Id == id).ExecuteDeleteAsync();
            return id;
        }                       
    }
}
