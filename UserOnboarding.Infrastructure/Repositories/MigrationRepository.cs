using Microsoft.EntityFrameworkCore;
using UserOnboarding.Domain.Entities;
using UserOnboarding.Infrastructure.Data;

namespace UserOnboarding.Infrastructure.Repositories
{
    public class MigrationRepository : IMigrationRepository
    {
        private readonly AppDbContext _context;

        public MigrationRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByMobileAsync(string mobileNumber)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.MobileNumber == mobileNumber);
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Users.Update(user);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
