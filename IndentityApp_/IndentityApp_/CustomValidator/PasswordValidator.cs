using IdentityApp_.Models;
using Microsoft.AspNetCore.Identity;

namespace IdentityApp_.CustomValidator
{
    public class PasswordValidator : IPasswordValidator<AppUser>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<AppUser> manager, AppUser user, string? password)
        {
            var errors = new List<IdentityError>();
            if (password!.ToLower().Contains(user.UserName!.ToLower()))
            {
                errors.Add(new()
                {
                    Code = "PasswordNoConatinsUserName",
                    Description = "Şifrədə istifadəçi adı olmamalıdı"
                });
            }
            if (password.StartsWith("1234"))
            {
                errors.Add(new()
                {
                    Code = "PasswordNoStart1234",
                    Description = "Şifrədə ardıcıl rəqəmlə başlaya bilməz!"
                });
            }
            if (errors.Any())
            {
                return Task.FromResult(IdentityResult.Failed(errors.ToArray()));
            }

            return Task.FromResult(IdentityResult.Success);
        }
    }
}
