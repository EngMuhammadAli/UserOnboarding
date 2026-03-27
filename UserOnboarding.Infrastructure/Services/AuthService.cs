using Org.BouncyCastle.Crypto.Generators;
using System;
using System.Collections.Generic;
using System.Text;
using UserOnboarding.Application.Interfaces;
using UserOnboarding.Domain.Entities;
using UserOnboarding.Infrastructure.Repositories;
using static System.Net.WebRequestMethods;

namespace UserOnboarding.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IOtpRepository _otpRepository;

        public AuthService(IUserRepository userRepository, IOtpRepository otpRepository)
        {
            _userRepository = userRepository;
            _otpRepository = otpRepository;
        }

        public async Task SendOtpAsync(string mobile)
        {
            var otp = new Random().Next(100000, 999999).ToString();

            await _otpRepository.AddOtpAsync(new OtpVerification
            {
                PhoneNumber = mobile,
                OtpCode = otp,
                Expiry = DateTime.UtcNow.AddMinutes(2)
            });

            await _otpRepository.SaveChangesAsync();

            // TODO: Integrate SMS sending service here
        }

        public async Task<bool> VerifyOtpAsync(string mobile, string otp)
        {
            var record = await _otpRepository.GetLatestOtpAsync(mobile, otp);

            if (record == null || record.Expiry < DateTime.UtcNow)
                return false;

            return true;
        }

        public async Task SetPinAsync(string mobile, string pin)
        {
            var user = await _userRepository.GetByMobileAsync(mobile);
            if (user == null)
                throw new Exception("User not found");

            user.PinHash = pin;

            await _userRepository.UpdateUserAsync(user);
            await _userRepository.SaveChangesAsync();
        }
    }
}
