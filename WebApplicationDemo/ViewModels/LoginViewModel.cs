using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationDemo.ViewModels
{
    [Keyless]
    [NotMapped]
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(14, MinimumLength = 6, ErrorMessage = "Password is either too short or too long!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
