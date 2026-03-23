using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Controllers
{
    public class NavController : Controller
    {
        private readonly AppDbCtx _ctx;

        public NavController(AppDbCtx ctx)
        {
            _ctx = ctx;
        }
        public IActionResult Index()
        {
            return View("Home/Index");
        }

        [HttpGet]
        public IActionResult Student()
        {
            var studDTO = new StudDTO()
            {
                Students = _ctx.Students.Where(s => s.IsActive == true).ToList()
            };
            if (studDTO != null)
            {
                return View("~/Views/Home/Student.cshtml", studDTO);
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Course()
        {
            var courses = _ctx.Courses.Where(c => c.IsActive == true).ToList();
            if (courses.Count > 0)
            {
                return View("~/Views/Home/Course.cshtml", courses);
            }
            else
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult Enrol()
        {
            var enrols = _ctx.Enrols.ToList();
            if (enrols.Count > 0)
            {
                return View("~/Views/Home/Enrol", enrols);
            }
            else
            {
                return View();
            }
        }
    }
}
