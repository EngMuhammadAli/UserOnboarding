using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UserOnboarding.Domain.Entities;

namespace UserOnboarding.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<OtpVerification> otpVerifications { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
