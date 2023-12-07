using Microsoft.AspNetCore.Identity;

namespace AspNetCoreIdentity.Web.Localizations
{
    public class LocalizationIdentityErrorDescriber:IdentityErrorDescriber
    {
        public override IdentityError DuplicateUserName(string userName)
        {
           return new IdentityError() { Code= "DuplicateUserName", Description = $"{userName} zaten daha önceden kayıt edilmiş." };
        }
        public override IdentityError DuplicateEmail(string email)
        {
            return new IdentityError() { Code = "DuplicateEmail", Description = $"{email} zaten daha önceden kayıt edilmiş." };
        }
        public override IdentityError PasswordTooShort(int length)
        {
            return new IdentityError() { Code = "PasswordTooShort", Description = "Şifre 6 karakterden kısa olamaz." };
        }
        
    }
}
