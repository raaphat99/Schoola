using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationDemo.Models
{
    public class Department
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int ID { get; set; }
        public string Name { get; set; }
        public string ManagerName { get; set; }
        public ICollection<Instructor> Instructors { get; set; }
        public ICollection<Course> Courses { get; set; }
        public ICollection<Trainee> Trainees { get; set; }
    }
}
