using Contacts.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Contacts.Infrastructure.Configurations
{
    public class ContactEntityConfiguration : IEntityTypeConfiguration<ContactEntity>
    {
        public void Configure(EntityTypeBuilder<ContactEntity> builder)
        {
            builder
                .HasKey(c => c.Id);

            builder
                .Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(ContactEntity.firstNameMaxLength);

            builder
                .Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(ContactEntity.lastNameMaxLength);

            builder
                .Property(c => c.PhoneNumber)
                .IsRequired();
            builder
                .HasIndex(c => c.PhoneNumber)
                .IsUnique();

            builder
                .Property(c => c.EmailAddress)
                .IsRequired();
            builder
                .HasIndex(c => c.EmailAddress)
                .IsUnique();
            builder
                .Property(c => c.EmailAddress)
                .HasMaxLength(ContactEntity.emailMaxLength);                          
        }
    }
}
