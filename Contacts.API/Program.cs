using Contacts.Application.Services;
using Contacts.Domain.Abstractions;
using Contacts.Domain.Entities;
using Contacts.Infrastructure;
using Contacts.Infrastructure.Entities;
using Contacts.Infrastructure.Mappers;
using Contacts.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
namespace Contacts.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped<IContactService, ContactService>();
            builder.Services.AddScoped<IContactRepository, EFContactRepository>();
            builder.Services.AddScoped<IMapper<Contact, ContactEntity>, ContactEntityMapper>();

            string ? contactsDBConnectionString = builder.Configuration.GetConnectionString(nameof(ContactsDbContext));
            builder.Services.AddDbContext<ContactsDbContext>(options =>
            {
                options.UseSqlServer(contactsDBConnectionString);
            });
            
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
