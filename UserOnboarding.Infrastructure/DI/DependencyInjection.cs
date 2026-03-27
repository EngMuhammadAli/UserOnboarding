using Microsoft.Extensions.DependencyInjection;
using UserOnboarding.Application.Interfaces;
using UserOnboarding.Application.Services;
using UserOnboarding.Infrastructure.Repositories;
using UserOnboarding.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using UserOnboarding.Application.Interfaces.UserOnboarding.Application.Interfaces;

namespace UserOnboarding.Infrastructure.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, string connectionString)
        {
            // Register DbContext
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            // Register Repositories
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IOtpRepository, OtpRepository>();
            services.AddScoped<IMigrationRepository, MigrationRepository>();


            // Register Services
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IMigrationService, MigrationService>();
            services.AddScoped<IUserService, UserService>();


            return services;
        }
    }
}