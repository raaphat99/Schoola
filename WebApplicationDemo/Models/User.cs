using System.ComponentModel.DataAnnotations;

namespace WebApplicationDemo.Models
{
    public class User
    {
        [Key]
        public int ID { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [StringLength(14, MinimumLength = 6, ErrorMessage = "Password is either too short or too long!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}
