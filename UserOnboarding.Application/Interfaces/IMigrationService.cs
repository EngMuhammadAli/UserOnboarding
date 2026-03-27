using System;
using System.Collections.Generic;
using System.Text;
using UserOnboarding.Domain.Entities;

namespace UserOnboarding.Application.Interfaces
{
    namespace UserOnboarding.Application.Interfaces
    {
        public interface IMigrationService
        {
            Task<bool> Validate(string mobileNumber, string cnic);
            Task CompleteMigration(string mobileNumber);
        }
    }
}
