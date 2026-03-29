using System;
using System.Collections.Generic;
using System.Text;
using UserOnboarding.Domain.Entities;

namespace UserOnboarding.Application.Interfaces
{
    public interface IOtpRepository
    {
        Task AddOtpAsync(OtpVerification otp);
        OtpVerification GenerateOtp(string phone);
        Task<OtpVerification> GetLatestOtpAsync(string mobileNumber, string code);
        Task SaveChangesAsync();
         bool VerifyOtp(string phone, string otp);
    }
}
