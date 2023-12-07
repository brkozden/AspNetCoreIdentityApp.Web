using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentity.Web.ViewModels
{
    public class PasswordChangeViewModel
    {
        [DataType(DataType.Password)]
        [Display(Name = "Mevcut Şifreniz")]
        [MinLength(6, ErrorMessage = "Şifreniz en az 6 karakter içermelidir.")]
        [Required(ErrorMessage = "Mevcut Şifre alanı boş geçilemez.")]
        public  string PasswordOld { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Yeni Şifre")]
        [MinLength(6, ErrorMessage = "Şifreniz en az 6 karakter içermelidir.")]
        [Required(ErrorMessage = "Yeni Şifre alanı boş geçilemez.")]
        public string PasswordNew { get; set; }
        [DataType(DataType.Password)]
        [Compare(nameof(PasswordNew), ErrorMessage = "Şifreler birbiriyle aynı değil.")]
        [Display(Name = "Yeni Şifre Tekrar")]
        [Required(ErrorMessage = "Yeni Şifre tekrar alanı boş geçilemez.")]
        [MinLength(6,ErrorMessage ="Şifreniz en az 6 karakter içermelidir.")]
        public string PasswordNewConfirm { get; set; }
    }
}
