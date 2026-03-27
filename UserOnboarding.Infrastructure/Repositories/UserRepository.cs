using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UserOnboarding.Application.Interfaces;
using UserOnboarding.Domain.Entities;
using UserOnboarding.Infrastructure.Data;

namespace UserOnboarding.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context) => _context = context;

        public User Add(User customer)
        {
            _context.Users.Add(customer);
            _context.SaveChanges();
            return customer;
        }

        public User? GetById(int id) => _context.Users.Find(id);

        public IEnumerable<User> GetAll() => _context.Users.ToList();

        public void Update(User customer)
        {
            _context.Users.Update(customer);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var customer = _context.Users.Find(id);
            if (customer != null)
            {
                _context.Users.Remove(customer);
                _context.SaveChanges();
            }
        }

        public async Task Activate(string mobile)
        {
            var user =  _context.Users.FirstOrDefault(x => x.MobileNumber == mobile);
            user.IsActive = true;
            _context.SaveChanges();
        }

        public async Task<bool> Exists(string mobile)
        {
           var data = await  _context.Users.FirstOrDefaultAsync(x => x.MobileNumber == mobile);
            if (data != null)
            {
                return true;
            }
            return false;

        }

        public async Task<User> GetByMobileAsync(string mobileNumber)
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
