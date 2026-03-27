using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserOnboarding.Application.Interfaces;
using UserOnboarding.Application.Interfaces.UserOnboarding.Application.Interfaces;
using UserOnboarding.Application.Services;

namespace UserOnboarding.API.Controllers
{
    [ApiController]
    [Route("api/v1/migration")]
    public class MigrationController : ControllerBase
    {
        private readonly IMigrationService _service;

        public MigrationController(IMigrationService service)
        {
            _service = service;
        }

        [HttpPost("validate")]
        public async Task<IActionResult> Validate(string mobile, string cnic)
        {
            return Ok(await _service.Validate(mobile, cnic));
        }

        [HttpPost("complete")]
        public async Task<IActionResult> Complete(string mobile)
        {
            await _service.CompleteMigration(mobile);
            return Ok();
        }
    }
}
