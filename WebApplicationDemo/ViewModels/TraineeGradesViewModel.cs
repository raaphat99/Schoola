using System.ComponentModel.DataAnnotations.Schema;
using WebApplicationDemo.Custom_Types;
using WebApplicationDemo.Data;
using WebApplicationDemo.Models;

namespace WebApplicationDemo.ViewModels
{
    [NotMapped]
    public class TraineeGradesViewModel
    {
        public int? TraineeID { get; set; }
        public string? TraineeName { get; set; }
        public string? CourseName { get; set; }
        public int CourseFullMark { get; set; }
        public int CourseSuccessMark { get; set; }
        public int TraineeMark { get; set; }
        public TraineeDegreeColor Color { get; set; }
    }
}
