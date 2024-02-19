using System.ComponentModel.DataAnnotations;

namespace Comixer.Models.Account
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;  

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [Display(Name = "Remember me?")]
        public string? ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }
}
