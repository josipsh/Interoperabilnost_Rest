using IisRest.Contracts.Services;
using Microsoft.AspNetCore.Mvc;

namespace IisRest.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _service;

        public ReportController(IReportService service)
        {
            _service = service;
        }

        [HttpGet("fullReport/{userId}")]
        public IActionResult GetFullReport(int userId)
        {
            return Ok();
        }
    }
}
