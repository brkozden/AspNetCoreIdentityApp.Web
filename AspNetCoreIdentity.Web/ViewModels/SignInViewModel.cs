using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentity.Web.ViewModels
{
    public class SignInViewModel
    {
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez.")]
        public string? Username { get; set; }
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre alanı boş geçilemez.")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}
