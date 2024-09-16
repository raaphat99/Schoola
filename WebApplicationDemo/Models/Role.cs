using System.ComponentModel.DataAnnotations;

namespace WebApplicationDemo.Models
{
    public class Role
    {
        [Key]
        public int ID { get; set; }

        [RegularExpression("^(Student|Admin|Supervisor)$", ErrorMessage = "Role must be either 'Student', 'Admin', or 'Supervisor'.")]
        public string Type { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
