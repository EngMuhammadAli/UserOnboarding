using System;
using System.Collections.Generic;
using System.Text;
using UserOnboarding.Domain.Entities;

namespace UserOnboarding.Application.Interfaces
{
    public interface IMigrationService
    {
        MigrationSession Start(int oldCustomerId);
        OtpVerification SendOtp(string phone);
        bool VerifyOtp(string phone, string otp);
        void SetPassword(int migrationId, string newPassword);
        MigrationSession? GetStatus(int migrationId);
    }
}
