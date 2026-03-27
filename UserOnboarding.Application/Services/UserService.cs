using System;
using System.Collections.Generic;
using System.Text;
using UserOnboarding.Application.DTOs;
using UserOnboarding.Application.Interfaces;
using UserOnboarding.Domain.Entities;

namespace UserOnboarding.Application.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Exists(string mobile)
        {
            return await _context.Users.AnyAsync(x => x.MobileNumber == mobile);
        }

        public async Task Register(RegisterDto dto)
        {
            var user = new User
            {
                MobileNumber = dto.MobileNumber,
                FullName = dto.FullName,
                Email = dto.Email,
                IsActive = false
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task Activate(string mobile)
        {
            var user = await _context.Users.FirstAsync(x => x.MobileNumber == mobile);
            user.IsActive = true;
            await _context.SaveChangesAsync();
        }
    }
}
