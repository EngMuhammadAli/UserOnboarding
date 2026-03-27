using System;
using System.Collections.Generic;
using System.Text;
using UserOnboarding.Application.DTOs;

namespace UserOnboarding.Application.Interfaces
{
    public interface IUserService
    {
        Task<bool> Exists(string mobile);
        Task Register(RegisterDto dto);
        Task Activate(string mobile);
    }
}
