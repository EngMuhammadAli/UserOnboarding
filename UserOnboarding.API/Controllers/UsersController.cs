using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserOnboarding.Application.DTOs;
using UserOnboarding.Application.Interfaces;

namespace UserOnboarding.API.Controllers
{
    [ApiController]
    [Route("api/v1/users")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        [HttpGet("check-existence")]
        public async Task<IActionResult> Check(string mobile)
        {
            return Ok(await _service.Exists(mobile));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            await _service.Register(dto);
            return Ok();
        }

        [HttpPost("activate")]
        public async Task<IActionResult> Activate(string mobile)
        {
            await _service.Activate(mobile);
            return Ok();
        }
    }
}
