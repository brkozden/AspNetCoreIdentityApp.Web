using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentity.Web.ViewModels
{
    public class ResetPasswordViewModel
    {
        [DataType(DataType.Password)]
        [Display(Name = "Yeni Şifre")]
        [Required(ErrorMessage = "Şifre alanı boş geçilemez.")]
        [MinLength(6, ErrorMessage = "Şifreniz en az 6 karakter içermelidir.")]
        public string? Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = " Yeni Şifre Tekrar")]
        [Required(ErrorMessage = "Şifre tekrar alanı boş geçilemez.")]
        [MinLength(6, ErrorMessage = "Şifreniz en az 6 karakter içermelidir.")]
        public string? ConfirmPassword { get; set; }
    }
}
