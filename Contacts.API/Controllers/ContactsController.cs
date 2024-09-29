using Microsoft.AspNetCore.Mvc;
using Contacts.Domain.Abstractions;
using Contacts.Domain.Entities;
using Contacts.API.DTOs;
using Contacts.API.Mappers;

namespace DeliveryProject.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;
        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ContactToCreateDTO request)
        {
            ContactToCreateDTOMapper mapper = new ContactToCreateDTOMapper();
            Guid id = await _contactService.CreateContactAsync(mapper.Map(request));
            return Ok(id);
        }
        [HttpGet]
        public async Task<IActionResult> Get([FromBody] ContactToGetDTO request)
        {
            Contact? contact = await _contactService.GetContactAsync(request.Id);
            return Ok(contact);
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Contact> allContacts = await _contactService.GetAllContactsAsync();
            return Ok(allContacts);
        }
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ContactToUpdateDTO request)
        {
            ContactToUpdateDTOMapper mapper = new ContactToUpdateDTOMapper();
            Guid id = await _contactService.UpdateContactAsync(mapper.Map(request));
            return Ok(id);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] ContactToDeleteDTO request)
        {
            Guid id = await _contactService.DeleteContactAsync(request.Id);
            return Ok(id);
        }
    }
}
