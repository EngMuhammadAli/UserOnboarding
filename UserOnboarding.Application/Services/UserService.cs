using System;
using System.Collections.Generic;
using System.Text;
using UserOnboarding.Application.DTOs;
using UserOnboarding.Application.Interfaces;
using UserOnboarding.Domain.Entities;
using UserOnboarding.Infrastructure.Repositories;

namespace UserOnboarding.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _customerRepository;

        public UserService(IUserRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<bool> Exists(string mobile)
        {
            return await _customerRepository.Exists(mobile);
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

            _customerRepository.Add(user);
        }

        public async Task Activate(string mobile)
        {
            await _customerRepository.Activate(mobile);
        }
    }
}
