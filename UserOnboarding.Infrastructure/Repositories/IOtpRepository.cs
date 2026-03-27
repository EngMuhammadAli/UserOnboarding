using System;
using System.Collections.Generic;
using System.Text;
using UserOnboarding.Domain.Entities;

namespace UserOnboarding.Infrastructure.Repositories
{
    public interface IOtpRepository
    {
        OtpVerification GenerateOtp(string phone);
        bool VerifyOtp(string phone, string otp);
    }
}
