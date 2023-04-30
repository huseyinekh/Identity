using IdentityApp_.CustomValidator;
using IdentityApp_.Data;
using IdentityApp_.Localizations;
using IdentityApp_.Models;

namespace IdentityApp_.Extensions
{
    public static class ServiceExtension
    {
        public static void AddIdentityExtension(this IServiceCollection services)
        {
            services.AddIdentity<AppUser, AppRole>(opt =>
            {
                opt.User.RequireUniqueEmail = true;
                opt.User.AllowedUserNameCharacters = "qwertyuiopasdfghjklzxcvbnm_1234567890";

                opt.Password.RequiredLength = 6;
                opt.Password.RequireNonAlphanumeric = true;
                opt.Password.RequireLowercase = true;
                opt.Password.RequireUppercase = true;
                opt.Password.RequireDigit = true;

                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
                opt.Lockout.MaxFailedAccessAttempts = 3;

            })
            .AddPasswordValidator<PasswordValidator>()
            .AddUserValidator<UserValidator>()
              .AddErrorDescriber<LocalizationIdentityDescriber>()
            .AddEntityFrameworkStores<AppDbContext>();
        }
    }
}
