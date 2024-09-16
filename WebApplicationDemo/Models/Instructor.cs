using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
using WebApplicationDemo.Data;

namespace WebApplicationDemo.Models
{
    public class Instructor
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }

        [ForeignKey("Department")]
        public int? DeptID { get; set; }
        public virtual Department Department { get; set; }

        [ForeignKey("Course")]
        public int? CourseID { get; set; }
        public virtual Course Course { get; set; }

    }
}
