using System;
using System.Collections.Generic;
using System.Text;
using UserOnboarding.Domain.Entities;

namespace UserOnboarding.Infrastructure.Repositories
{
    public interface IUserRepository
    {
        User Add(User customer);
        Task Activate(string mobile);
        Task<bool> Exists(string mobile);
        Task<User> GetByMobileAsync(string mobileNumber);
        Task UpdateUserAsync(User user);
        Task SaveChangesAsync();
    }
}
