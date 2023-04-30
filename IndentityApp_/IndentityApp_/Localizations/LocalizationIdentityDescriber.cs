using Microsoft.AspNetCore.Identity;

namespace IdentityApp_.Localizations
{
    public class LocalizationIdentityDescriber : IdentityErrorDescriber
    {
        public override IdentityError DuplicateUserName(string userName)
        {
            return new()
            {
                Code = "DuplicatedUserName",
                Description = $"{userName} -istifadəçi adı artıq mövcuddur!"
            };
        }

        public override IdentityError DuplicateEmail(string email)
        {
            return new()
            {
                Code = "DuplicatedEmail",
                Description = $"{email} -email adı artıq mövcuddur!"
            };
        }
        public override IdentityError PasswordTooShort(int length)
        {
            return new()
            {
                Code = "PasswordTooShort",
                Description = $"parol ən az ${length} simvoldan ibarət olmalıdır"
            };
        }
    }
}
