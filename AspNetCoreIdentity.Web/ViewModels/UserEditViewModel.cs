using System.ComponentModel.DataAnnotations;

namespace AspNetCoreIdentity.Web.ViewModels
{
    public class UserEditViewModel
    {
        [Display(Name = "Kullanıcı Adı")]

        public string Username { get; set; }
        [Display(Name = "Email")]
       
        [EmailAddress(ErrorMessage = "Email formatı yanlış.")]
        public string Email { get; set; }
        [Display(Name = "Telefon")]
        
        public string Phone { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Doğum Tarihi")]
        public DateTime BirthDate { get; set; }
        [Display(Name = "Şehir")]
        public string City { get; set; }

        [Display(Name = "Profil Resmi")]
        public IFormFile Picture { get; set; }

        [Display(Name = "Cinsiyet")]
        public string Gender { get; set; }

        [Display(Name = "Hakkında")]
        public string About { get; set; }



    }
}
