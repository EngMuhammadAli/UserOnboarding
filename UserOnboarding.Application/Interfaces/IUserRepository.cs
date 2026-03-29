using System;
using System.Collections.Generic;
using System.Text;
using UserOnboarding.Domain.Entities;

namespace UserOnboarding.Application.Interfaces
{
    public interface IUserRepository
    {
        User Add(User customer);
        User? GetById(int id);
        IEnumerable<User> GetAll();
        void Update(User customer);
        void Delete(int id);

        // Business specific
        Task Activate(string mobile);
        Task<bool> Exists(string mobile);
        Task<User> GetByMobileAsync(string mobileNumber);

        // Async operations (recommended for services)
        Task UpdateUserAsync(User user);
        Task SaveChangesAsync();
    }
}
