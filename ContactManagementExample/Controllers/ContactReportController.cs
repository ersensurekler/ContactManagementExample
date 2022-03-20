using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/contact-report")]
    [ApiController]
    public class ContactReportController : BaseController
    {
        public IActionResult Index()
        {
            return null;
        }
    }
}
