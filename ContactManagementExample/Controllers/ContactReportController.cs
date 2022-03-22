using Business.Interfaces.ContactReports;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/contact-report")]
    [ApiController]
    public class ContactReportController : BaseController
    {
        private readonly IContactReportService _contactReportService;
        public ContactReportController(
            IContactReportService contactReportService)
        {
            _contactReportService = contactReportService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var persons = await _contactReportService.GetAllReportSend();
            if (!persons.Success)
                return BadRequest(persons.Message);

            return Ok();
        }
    }
}
