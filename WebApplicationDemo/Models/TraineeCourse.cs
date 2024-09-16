using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebApplicationDemo.Models
{
    public class TraineeCourse
    {
        [Key]
        public int ID { get; set; }

        [ForeignKey("Course")]
        public int CourseID { get; set; }
        public virtual Course Course { get; set; }

        [ForeignKey("Trainee")]
        public int TraineeID { get; set; }
        public virtual Trainee Trainee { get; set; }

        [Range(0, 200, ErrorMessage = "Trainee Degree must be between 0 an 200!")]
        public int TraineeDegree { get; set; }
    }
}
