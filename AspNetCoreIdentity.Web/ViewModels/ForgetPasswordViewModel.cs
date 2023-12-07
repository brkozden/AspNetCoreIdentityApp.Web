using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentity.Web.ViewModels
{
    public class ForgetPasswordViewModel
    {
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email alanı boş geçilemez.")]
        [EmailAddress(ErrorMessage = "Email formatı yanlış.")]
        public string Email { get; set; }
    }
}
