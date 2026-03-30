using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.DTOs;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.ViewModels;

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
        public IActionResult Student(string search, int? id)
        {
            var students = new StudentVM();
            if (!string.IsNullOrEmpty(search))
            {
                students.Students = _ctx.Students.Where(s =>
                (
                    s.StudNum.Contains(search) ||
                    s.FirstName.Contains(search) ||
                    s.LastName.Contains(search) ||
                    s.Email.Contains(search)
                ) && s.IsActive == true
                ).ToList();

                if (students.Students != null && students.Students.Count() > 0)
                {
                    return View("~/Views/Home/Student.cshtml", students);
                }
                return View("~/Views/Home/Student.cshtml");
            }

            if (id != null)
            {
                students.Students = _ctx.Students.Where(s => s.IsActive == true).ToList();
                var student = _ctx.Students.Where(s => s.Id == id && s.IsActive == true).FirstOrDefault();
                if (student != null)
                {
                    students.NewStudent = new StudDTO()
                    {
                        Id = student.Id,
                        StudNum = student.StudNum,
                        FirstName = student.FirstName,
                        LastName = student.LastName,
                        Email = student.Email,

                    };
                }

                return View("~/Views/Home/Student.cshtml", students);
            }


            students.Students = _ctx.Students.Where(s => s.IsActive == true).ToList();

            if (students.Students != null && students.Students.Count() > 0)
            {
                return View("~/Views/Home/Student.cshtml", students);
            }
            return View("~/Views/Home/Student.cshtml");

        }

        [HttpGet]
        public IActionResult Course()
        {
            var courses = _ctx.Courses.Where(c => c.IsActive == true).ToList();
            if (courses.Count > 0)
            {
                return View("~/Views/Home/Course.cshtml", courses);
            }
            return View("~/Views/Home/Course.cshtml");

        }

        [HttpGet]
        public IActionResult Enrol()
        {
            var enrols = _ctx.Enrols.ToList();
            if (enrols.Count > 0)
            {
                return View("~/Views/Home/Enrol", enrols);
            }
            return View("~/Views/Home/Enrol");

        }
    }
}
