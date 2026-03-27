using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserOnboarding.Application.DTOs;
using UserOnboarding.Application.Interfaces;

namespace UserOnboarding.API.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _service;

        public AuthController(IAuthService service)
        {
            _service = service;
        }

        [HttpPost("send-otp")]
        public async Task<IActionResult> SendOtp(SendOtpDto dto)
        {
            await _service.SendOtpAsync(dto.MobileNumber);
            return Ok("OTP Sent");
        }

        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp(VerifyOtpDto dto)
        {
            var result = await _service.VerifyOtpAsync(dto.MobileNumber, dto.Otp);
            return Ok(result);
        }

        [HttpPost("set-pin")]
        public async Task<IActionResult> SetPin(SetPinDto dto)
        {
            await _service.SetPinAsync(dto.MobileNumber, dto.Pin);
            return Ok();
        }
    }
}
