using System;
using System.Collections.Generic;
using System.Text;
using UserOnboarding.Domain.Entities;

namespace UserOnboarding.Infrastructure.Repositories
{
    public class OtpRepository : IOtpRepository
    {
        private readonly AppDbContext _context;
        public OtpRepository(AppDbContext context) => _context = context;

        public OtpVerification GenerateOtp(string phone)
        {
            var otp = new Random().Next(100000, 999999).ToString();
            var record = new OtpVerification
            {
                PhoneNumber = phone,
                OtpCode = otp,
                Expiry = DateTime.UtcNow.AddMinutes(5)
            };
            _context.OtpVerifications.Add(record);
            _context.SaveChanges();
            return record;
        }

        public bool VerifyOtp(string phone, string otp)
        {
            var record = _context.OtpVerifications
                .FirstOrDefault(o => o.PhoneNumber == phone && o.OtpCode == otp);

            if (record == null || record.Expiry < DateTime.UtcNow) return false;

            record.IsVerified = true;
            _context.SaveChanges();
            return true;
        }
    }

}
