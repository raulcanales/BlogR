using System.ComponentModel.DataAnnotations;
using System.Configuration;

namespace BlogR.Web.Models
{
    public class RegisterUserViewModel
    {
        [Required]
        [StringLength(40, MinimumLength = 2)]
        public string Nickname { get; set; }

        [Required]
        //[RegexStringValidator(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,})+)$")]
        public string Email { get; set; }

        [Required]
        [StringLength(40, MinimumLength = 6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string ConfirmPassword { get; set; }


    }
}
