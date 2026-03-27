using System;
using System.Collections.Generic;
using System.Text;
using UserOnboarding.Application.Interfaces;
using UserOnboarding.Application.Interfaces.UserOnboarding.Application.Interfaces;
using UserOnboarding.Domain.Entities;
using UserOnboarding.Infrastructure.Data;
using UserOnboarding.Infrastructure.Repositories;

namespace UserOnboarding.Application.Services
{
    public class MigrationService : IMigrationService
    {
        private readonly IMigrationRepository _repository;

        public MigrationService(IMigrationRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Validate(string mobileNumber, string cnic)
        {
            var user = await _repository.GetUserByMobileAsync(mobileNumber);

            if (user == null)
                return false;

            // TODO: Replace with real CNIC validation logic
            bool isValid = !string.IsNullOrEmpty(cnic);

            return isValid;
        }

        public async Task CompleteMigration(string mobileNumber)
        {
            var user = await _repository.GetUserByMobileAsync(mobileNumber);

            if (user == null)
                throw new Exception("User not found");

            user.IsMigrated = true;

            await _repository.UpdateUserAsync(user);
            await _repository.SaveChangesAsync();
        }
    }

}
