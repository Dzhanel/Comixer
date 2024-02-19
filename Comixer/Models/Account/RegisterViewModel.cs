using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Comixer.Models.Account
{
    public class RegisterViewModel
    {
        [Required]
        public string Username { get; set; } = null!;
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = null!;
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = null!;

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; } = null!;
        public string? ReturnUrl { get; set; }
    }
}
