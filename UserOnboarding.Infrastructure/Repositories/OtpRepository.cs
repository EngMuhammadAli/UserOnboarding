using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UserOnboarding.Domain.Entities;
using UserOnboarding.Infrastructure.Data;

namespace UserOnboarding.Infrastructure.Repositories
{
    public class OtpRepository : IOtpRepository
    {
        private readonly AppDbContext _context;
        public OtpRepository(AppDbContext context) => _context = context;

        public async Task AddOtpAsync(OtpVerification otp)
        {
            await _context.otpVerifications.AddAsync(otp);
        }

        public OtpVerification GenerateOtp(string phone)
        {
            var otp = new Random().Next(100000, 999999).ToString();
            var record = new OtpVerification
            {
                PhoneNumber = phone,
                OtpCode = otp,
                Expiry = DateTime.UtcNow.AddMinutes(5)
            };
            _context.otpVerifications.Add(record);
            _context.SaveChanges();
            return record;
        }

        public async Task<OtpVerification> GetLatestOtpAsync(string mobileNumber, string code)
        {
            return await _context.otpVerifications
                .Where(x => x.PhoneNumber == mobileNumber && x.OtpCode == code)
                .OrderByDescending(x => x.Id)
                .FirstOrDefaultAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public bool VerifyOtp(string phone, string otp)
        {
            var record = _context.otpVerifications
                .FirstOrDefault(o => o.PhoneNumber == phone && o.OtpCode == otp);

            if (record == null || record.Expiry < DateTime.UtcNow) return false;

            record.IsVerified = true;
            _context.SaveChanges();
            return true;
        }
    }

}
