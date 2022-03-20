using Business.Interfaces.Contacts;
using Entities.Concrete.Contacts;
using Entities.Concrete.Persons;
using Entities.Dtos.Contacts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/contact")]
    [ApiController]
    public class ContactController : BaseController
    {
        private readonly IContactService _contactService;
        public ContactController(
            IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var contact = await _contactService.GetById(id);
            if (!contact.Success)
                return BadRequest(contact.Message);

            return Ok(contact.Data);
        }

        [HttpPost("save-person")]
        public async Task<IActionResult> Save(Person person)
        {
            var result = await _contactService.Save(person);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok();
        }
    }
}
