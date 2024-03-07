using System.ComponentModel.DataAnnotations;

namespace Comixer.Models.Account
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Username or Email")]
        public string LoginCredential { get; set; } = null!;  

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;
        public string? ReturnUrl { get; set; }
        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
