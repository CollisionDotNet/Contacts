using Contacts.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Infrastructure
{
    public class ContactsDbContext : DbContext
    {
        public DbSet<ContactEntity> Contacts { get; set; } = null!;
        public ContactsDbContext(DbContextOptions<ContactsDbContext> options) : base(options)
        {

        }
    }
}
