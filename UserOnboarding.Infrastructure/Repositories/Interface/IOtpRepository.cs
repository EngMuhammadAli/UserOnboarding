using System;
using System.Collections.Generic;
using System.Text;
using UserOnboarding.Domain.Entities;
using static System.Net.WebRequestMethods;

namespace UserOnboarding.Infrastructure.Repositories
{
    public interface IOtpRepository
    {
        OtpVerification GenerateOtp(string phone);
        bool VerifyOtp(string phone, string otp);
        Task AddOtpAsync(OtpVerification otp);
        Task<OtpVerification> GetLatestOtpAsync(string mobileNumber, string code);
        Task SaveChangesAsync();
    }
}
