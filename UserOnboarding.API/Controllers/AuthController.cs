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
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("send-otp")]
        public async Task<IActionResult> SendOtp([FromBody] OtpRequestDto dto)
        {
            await _authService.SendOtpAsync(dto.MobileNumber);
            return Ok(new { message = "OTP sent successfully" });
        }

        [HttpPost("verify-otp")]
        public async Task<IActionResult> VerifyOtp([FromBody] OtpVerifyDto dto)
        {
            bool isValid = await _authService.VerifyOtpAsync(dto.MobileNumber, dto.Code);
            if (!isValid)
                return BadRequest(new { message = "Invalid or expired OTP" });

            return Ok(new { message = "OTP verified successfully" });
        }

        [HttpPost("set-pin")]
        public async Task<IActionResult> SetPin([FromBody] SetPinDto dto)
        {
            await _authService.SetPinAsync(dto.MobileNumber, dto.Pin);
            return Ok(new { message = "PIN set successfully" });
        }
    }

}
