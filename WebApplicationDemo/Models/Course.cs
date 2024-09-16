using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationDemo.Models
{
    public class Course
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        [Range(10, 200, ErrorMessage = "Course Degree must be between 10 and 200!")]
        public int CourseDegree { get; set; }

        [Range(10, 200, ErrorMessage = "Passing Degree must be between 10 and 200!")]
        public int PassDegree { get; set; }

        public ICollection<Department> Departments { get; set; }
        public ICollection<Instructor> Instructors { get; set; }
    }
}
