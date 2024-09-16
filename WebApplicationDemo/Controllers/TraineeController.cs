using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System;
using WebApplicationDemo.Data;
using WebApplicationDemo.Interfaces;
using WebApplicationDemo.Models;
using WebApplicationDemo.Repository;
using WebApplicationDemo.Services;
using WebApplicationDemo.ViewModels;

namespace WebApplicationDemo.Controllers
{
    public class TraineeController : Controller
    {
        protected readonly ITPQ3Context _iTPQ3Context;
        private readonly ITraineeService _traineeService;
        //private readonly IRepository<Trainee> DbRepository;

        public TraineeController(/*IRepository<Trainee> _DbRepository,*/ ITraineeService traineeService, ITPQ3Context iTPQ3Context)
        {
            _iTPQ3Context = iTPQ3Context;
            _traineeService = traineeService;
            //DbRepository = _DbRepository;
        }

        public IActionResult Index()
        {
            return View(_traineeService.GetAll());
        }

        public IActionResult Details(int id)
        {
            string? traineeName = _iTPQ3Context.Trainees?.Find(id)?.Name.ToString();
            ViewBag.ID = id;
            ViewBag.Name = traineeName;
            return View(_traineeService.CourseGrade(id));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ICollection<Department> departments = _iTPQ3Context.Departments.ToList();
            ViewBag.DeptList = departments;
            return View(new Trainee());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Insert(Trainee trainee, IFormFile traineePhoto)
        {
            string fileName = $"{traineePhoto?.FileName}";
            FileStream fileStream = new FileStream($"wwwroot/media/images/{fileName}", FileMode.Create);
            await traineePhoto.CopyToAsync(fileStream);
            fileStream.Close();

            if (ModelState.IsValid)
            {
                trainee.ImageUrl = fileName != "" ? fileName : "user_icon.png";
                _iTPQ3Context.Trainees.Add(trainee);
                _iTPQ3Context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ICollection<Department> departments = _iTPQ3Context.Departments.ToList();
                ViewData["DeptList"] = departments;
                return View("Create", trainee);
            }

        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Trainee trainee = _iTPQ3Context.Trainees.Find(id);
            ICollection<Department> departments = _iTPQ3Context.Departments.ToList();
            ViewBag.DeptList = departments;
            return View(trainee);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Trainee newTrainee, IFormFile traineePhoto)
        {
            string fileName = $"{traineePhoto.FileName}";
            FileStream fileStream = new FileStream($"wwwroot/media/images/{fileName}", FileMode.Create);
            await traineePhoto.CopyToAsync(fileStream);
            fileStream.Close();

            if (ModelState.IsValid)
            {
                newTrainee.ImageUrl = fileName;
                _iTPQ3Context.Trainees.Update(newTrainee);
                _iTPQ3Context.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ICollection<Department> departments = _iTPQ3Context.Departments.ToList();
                ViewData["DeptList"] = departments;
                return Content("Form Data is Invalid!");
                return View(newTrainee);
            }

        }

        public IActionResult Destroy(int id)
        {
            return View("ConfirmDelete");
        }

        public IActionResult Delete(Trainee trainee)
        {
            _iTPQ3Context.Trainees.Remove(trainee);
            _iTPQ3Context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult UserEmailIsUnique(string email)
        {
            int? routeId = RouteData.Values["id"] != null ? (int)RouteData.Values["id"] : null;
            Trainee trainee = _iTPQ3Context.Trainees.FirstOrDefault(t => t.Email == email);
            return (trainee == null && _iTPQ3Context?.Trainees?.Find(routeId) == null) ? Json(true) : Json(false);
        }
    }
}
