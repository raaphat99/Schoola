using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationDemo.Data;
using WebApplicationDemo.Models;
using WebApplicationDemo.Repository;

namespace WebApplicationDemo.Controllers
{
    public class InstructorController : Controller
    {
        protected readonly ITPQ3Context _iTPQ3Context;
        public InstructorController(ITPQ3Context iTPQ3Context)
        {
            _iTPQ3Context = iTPQ3Context;
        }

        public IActionResult Index()
        {
            ICollection<Instructor> instructors = _iTPQ3Context.Instructors.Include(ins => ins.Department).ToList();
            return View(instructors);
        }

        public IActionResult Details(int id)
        {
            Instructor instructor = _iTPQ3Context.Instructors.Include(ins => ins.Department).FirstOrDefault(ins => ins.ID == id);
            return View(instructor);
        }
    }
}
