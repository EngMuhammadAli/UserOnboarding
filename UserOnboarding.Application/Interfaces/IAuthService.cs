using System;
using System.Collections.Generic;
using System.Text;

namespace UserOnboarding.Application.Interfaces
{
    public interface IAuthService
    {
        Task SendOtpAsync(string mobile);
        Task<bool> VerifyOtpAsync(string mobile, string otp);
        Task SetPinAsync(string mobile, string pin);
    }
}
