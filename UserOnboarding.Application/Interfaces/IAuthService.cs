using System;
using System.Collections.Generic;
using System.Text;

namespace UserOnboarding.Application.Interfaces
{
    public interface IAuthService
    {
        Task SendOtpAsync(string mobileNumber);
        Task<bool> VerifyOtpAsync(string mobileNumber, string otp);
        Task SetPinAsync(string mobileNumber, string pin);
    }
}
