using Microsoft.AspNetCore.Identity;
using System.Diagnostics.CodeAnalysis;

namespace AspNetCoreIdentity.Web.Models
{
    public class AppUser:IdentityUser
    {
        [AllowNull]
        public string City { get; set; }
        [AllowNull]
        public string Picture { get; set; }
        [AllowNull]
        public DateTime BirthDay { get; set; }
        [AllowNull]
        public string Gender { get; set; }

        [AllowNull]
        public string About { get; set; }





    }
}
