using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Drawing;
using WebApplicationDemo.Custom_Types;
using WebApplicationDemo.Data;
using WebApplicationDemo.Interfaces;
using WebApplicationDemo.Models;
using WebApplicationDemo.ViewModels;

namespace WebApplicationDemo.Services
{
    public class TraineeService : ITraineeService
    {
        protected readonly ITPQ3Context _iTPQ3Context;

        public TraineeService(ITPQ3Context iTPQ3Context)
        {
            _iTPQ3Context = iTPQ3Context;
        }

        public ICollection<Trainee> GetAll()
        {
            return _iTPQ3Context.Trainees.Include(t => t.Department).ToList();
        }

        public ICollection<TraineeGradesViewModel> CourseGrade(int id)
        {
            ICollection<TraineeGradesViewModel> courseWithGradeList = new List<TraineeGradesViewModel>();
            var traineeCourses = _iTPQ3Context.TraineeCourses.Where(row => row.TraineeID == id).ToList();
            string? traineeName = _iTPQ3Context.Trainees?.Find(id)?.Name.ToString();

            foreach (var row in traineeCourses)
            {
                Course? course = _iTPQ3Context?.Courses?.Find(row.CourseID);

                string courseName = course.Name;
                int courseFullMark = course.CourseDegree;
                int courseSuccessMark = course.PassDegree;
                int traineeMark = row.TraineeDegree;
                TraineeDegreeColor color = traineeMark >= courseSuccessMark ? TraineeDegreeColor.Green : TraineeDegreeColor.Red;

                TraineeGradesViewModel courseWithGrade = new TraineeGradesViewModel()
                {
                    TraineeID = id,
                    TraineeName = traineeName,
                    CourseName = courseName,
                    CourseFullMark = courseFullMark,
                    CourseSuccessMark = courseSuccessMark,
                    TraineeMark = traineeMark,
                    Color = color,
                };
                courseWithGradeList.Add(courseWithGrade);
            }
            return courseWithGradeList;
        }
    }
}
