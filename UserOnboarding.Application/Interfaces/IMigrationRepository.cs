using System;
using System.Collections.Generic;
using System.Text;
using UserOnboarding.Domain.Entities;

namespace UserOnboarding.Infrastructure.Repositories
{
    public interface IMigrationRepository
    {
        Task<User> GetUserByMobileAsync(string mobileNumber);
        Task UpdateUserAsync(User user);
        Task SaveChangesAsync();
    }
}
