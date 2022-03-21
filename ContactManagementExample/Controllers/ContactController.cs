using Business.Interfaces.Contacts;
using Entities.Concrete.Contacts;
using Entities.Concrete.Persons;
using Entities.Dtos.Contacts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/contact")]
    [ApiController]
    public class ContactController : BaseController
    {
        private readonly IPersonService _personService;
        private readonly IContactService _contactService;
        public ContactController(
            IPersonService personService,
            IContactService contactService)
        {
            _personService = personService;
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var persons = await _personService.Get();
            if (!persons.Success)
                return BadRequest(persons.Message);

            return Ok(persons.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var person = await _personService.GetById(id);
            if (!person.Success)
                return BadRequest(person.Message);

            return Ok(person.Data);
        }

        [HttpGet("person-contacts/{personId}")]
        public async Task<IActionResult> GetContactsByPersonId(Guid personId)
        {
            var person = await _contactService.GetByPersonId(personId);
            if (!person.Success)
                return BadRequest(person.Message);

            return Ok(person.Data);
        }

        [HttpPost("save-person")]
        public async Task<IActionResult> Save(PersonDto person)
        {
            var result = await _personService.Save(person);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpPost("save-contact")]
        public async Task<IActionResult> SaveContact(ContactDto contact)
        {
            var result = await _contactService.Save(contact);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpPost("delete-person")]
        public async Task<IActionResult> DeleteContact(PersonDto person)
        {
            var result = await _personService.Delete(person);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok();
        }

        [HttpPost("delete-contact")]
        public async Task<IActionResult> DeleteContact(ContactDto contact)
        {
            var result = await _contactService.Delete(contact);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok();
        }
    }
}
