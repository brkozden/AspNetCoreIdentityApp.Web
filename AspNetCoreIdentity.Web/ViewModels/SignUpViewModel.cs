using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentity.Web.ViewModels
{
    public class SignUpViewModel
    {
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage ="Kullanıcı adı boş geçilemez.")]
        public string Username { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email alanı boş geçilemez.")]
        [EmailAddress(ErrorMessage = "Email formatı yanlış.")]
        public string Email { get; set; }
        [Display(Name = "Telefon")]
        [Required(ErrorMessage = "Telefon alanı boş geçilemez.")]
        public string Phone { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Şifre")]
        [Required(ErrorMessage = "Şifre alanı boş geçilemez.")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage ="Şifreler aynı değil.")]
        [Display(Name = "Şifre Tekrar")]
        [Required(ErrorMessage = "Şifre tekrar alanı boş geçilemez.")]
        [MinLength(6, ErrorMessage = "Şifreniz en az 6 karakter içermelidir.")]
        public string PasswordConfirm { get; set; }
    }
}
