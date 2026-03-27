using System;
using System.Collections.Generic;
using System.Text;
using UserOnboarding.Application.Interfaces;
using UserOnboarding.Domain.Entities;

namespace UserOnboarding.Application.Services
{
    public class MigrationService : IMigrationService
    {
        private readonly AppDbContext _context;
        private readonly IOtpRepository _otpRepo;

        public MigrationService(AppDbContext context, IOtpRepository otpRepo)
        {
            _context = context;
            _otpRepo = otpRepo;
        }

        public MigrationSession Start(int oldCustomerId)
        {
            var migration = new MigrationSession { OldCustomerId = oldCustomerId };
            _context.MigrationSessions.Add(migration);
            _context.SaveChanges();
            return migration;
        }

        public OtpVerification SendOtp(string phone) => _otpRepo.GenerateOtp(phone);

        public bool VerifyOtp(string phone, string otp) => _otpRepo.VerifyOtp(phone, otp);

        public void SetPassword(int migrationId, string newPassword)
        {
            var migration = _context.MigrationSessions.Find(migrationId);
            if (migration == null) throw new Exception("Migration not found");
            migration.PasswordUpdated = true;
            _context.SaveChanges();
        }

        public MigrationSession? GetStatus(int migrationId) => _context.MigrationSessions.Find(migrationId);
    }

}
