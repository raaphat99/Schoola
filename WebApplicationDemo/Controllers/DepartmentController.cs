using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using WebApplicationDemo.CustomFilters;
using WebApplicationDemo.Data;
using WebApplicationDemo.Models;

namespace WebApplicationDemo.Controllers
{
    [ExceptionFilter]
    public class DepartmentController : Controller
    {
        protected readonly ITPQ3Context _ITPQ3Context;

        public DepartmentController(ITPQ3Context iTPQ3Context)
        {
            _ITPQ3Context = iTPQ3Context;
        }
        public IActionResult Index()
        {
            //throw new Exception("Simulating an exception to test the custom filter....");
            ICollection<Department> departments = _ITPQ3Context.Departments.Include(dept => dept.Courses).ToList();
            return View(departments);
        }

        public IActionResult Courses(int id)
        {
            Department department = _ITPQ3Context.Departments.Include(dept => dept.Courses).FirstOrDefault(dept => dept.ID == id);
            ViewBag.DeptID = id;
            ICollection<Course> allCourses = _ITPQ3Context.Courses.ToList();
            ICollection<Course> registeredCourses = department.Courses.ToList();
            var unregisteredCourses = allCourses.Except(registeredCourses);
            ViewBag.UnregisteredCourses = unregisteredCourses;
            return View(department.Courses.ToList());
        }

        public IActionResult AddCourse(int id, List<int> coursesIDsToAdd)
        {
            Department department = _ITPQ3Context.Departments.Include(dept => dept.Courses).FirstOrDefault(dept => dept.ID == id);
            foreach (int courseID in coursesIDsToAdd)
            {
                Course crs = _ITPQ3Context.Courses.FirstOrDefault(c => c.ID == courseID);
                department.Courses.Add(crs);
            }
            _ITPQ3Context.SaveChanges();
            return Content("Added");
        }

        public IActionResult DeleteCourse(int id, int courseID)
        {
            Department department = _ITPQ3Context.Departments.Include(dept => dept.Courses).FirstOrDefault(dept => dept.ID == id);
            Course course = department.Courses.FirstOrDefault(crs => crs.ID == courseID);
            department.Courses.Remove(course);
            _ITPQ3Context.SaveChanges();
            return Content("Deleted");
        }
    }
}
