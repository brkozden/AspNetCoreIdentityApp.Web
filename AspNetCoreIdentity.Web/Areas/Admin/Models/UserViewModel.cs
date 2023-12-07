using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentity.Web.Areas.Admin.Models
{
    public class UserViewModel
    {
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez.")]
        public string ID { get; set; }
        [Display(Name = "Kullanıcı Adı")]
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez.")]
        public string Name { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email alanı boş geçilemez.")]
        [EmailAddress(ErrorMessage = "Email formatı yanlış.")]
        public string Email { get; set; }
        [Display(Name = "Telefon")]
        [Required(ErrorMessage = "Telefon alanı boş geçilemez.")]
        public string Phone { get; set; }
      
    }
}
