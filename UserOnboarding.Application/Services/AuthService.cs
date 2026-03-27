using System;
using System.Collections.Generic;
using System.Text;
using UserOnboarding.Application.Interfaces;
using UserOnboarding.Domain.Entities;

namespace UserOnboarding.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public async Task SendOtpAsync(string mobile)
        {
            var otp = new Random().Next(100000, 999999).ToString();

            _context.Otps.Add(new Otp
            {
                MobileNumber = mobile,
                Code = otp,
                Expiry = DateTime.UtcNow.AddMinutes(2)
            });

            await _context.SaveChangesAsync();

            // TODO: Integrate SMS service
        }

        public async Task<bool> VerifyOtpAsync(string mobile, string otp)
        {
            var record = await _context.Otps
                .Where(x => x.MobileNumber == mobile && x.Code == otp)
                .OrderByDescending(x => x.Id)
                .FirstOrDefaultAsync();

            if (record == null || record.Expiry < DateTime.UtcNow)
                return false;

            return true;
        }

        public async Task SetPinAsync(string mobile, string pin)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.MobileNumber == mobile);

            user.PinHash = BCrypt.Net.BCrypt.HashPassword(pin);

            await _context.SaveChangesAsync();
        }
    }
}
