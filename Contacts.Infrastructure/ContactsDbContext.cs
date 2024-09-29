using Microsoft.EntityFrameworkCore;
using Contacts.Infrastructure.Configurations;
using Contacts.Infrastructure.Entities;

namespace Contacts.Infrastructure
{
    public class ContactsDbContext : DbContext
    {
        public DbSet<ContactEntity> Contacts { get; set; } = null!;
        public ContactsDbContext(DbContextOptions<ContactsDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContactEntityConfiguration());
        }
    }
}
