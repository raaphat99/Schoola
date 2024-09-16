using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationDemo.Models;

namespace WebApplicationDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
