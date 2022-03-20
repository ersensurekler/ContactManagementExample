using Business.Interface.Contacts;
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
            var result = await _contactService.GetById(id);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Data);
        }
    }
}
