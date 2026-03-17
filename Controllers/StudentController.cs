using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbCtx _ctx;
        private readonly ILogger<StudentController> _logger;
        public StudentController(AppDbCtx ctx, ILogger<StudentController> logger) {
            _ctx = ctx;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult StudentDash()
        {
            var students = _ctx.Students.Where(s => s.IsActive == true).ToList();
            if (students.Count > 0)
            {
                return View(students);
            }
            else 
            {
                return View();
            }
        }

        [HttpGet]
        public IActionResult SearchStudent(string search)
        {
            var student = _ctx.Students.Where(s => s.IsActive == true && (s.StudNum.Contains(search) || s.FirstName.Contains(search) || s.LastName.Contains(search)));
            if (student != null)
            {
                return View(student);
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public async Task<IActionResult> StudentForm(StudDTO stud)
        {
            if (!ModelState.IsValid) 
            {
                if(_ctx.Students.Any(s => s.StudNum == stud.StudNum || s.Email == stud.Email)) 
                {
                    ModelState.AddModelError("Student", "Student number or email already exists!");
                    return View("~/Views/Home/CreateStudent.cshtml", stud);
                }
                ModelState.AddModelError("Student", "Please enter valid student details.");
                return View(stud);
            }
            Student student = new Student() {
                StudNum = stud.StudNum,
                FirstName = stud.FirstName,
                LastName = stud.LastName,
                Email = stud.Email
            };

            await _ctx.AddAsync(student);
            await _ctx.SaveChangesAsync();
            return RedirectToAction("Nav","StudDash");
        }

        [HttpPost]
        public async Task<IActionResult> EditStudent(StudDTO stud)
        {
            if (!ModelState.IsValid) 
            {
                ModelState.AddModelError("Student", "Please fill all fields");
                return View("~/Views/Home/EditStudent.cshtml", stud);
            }

            var student = await _ctx.Students.FirstOrDefaultAsync(s=>s.Id == stud.Id);
            if (student == null) 
            {
                return NotFound();
            }          

            _ctx.Update(student);
            await _ctx.SaveChangesAsync();
            return RedirectToAction("Nav", "StudDash");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteStudent(int id) 
        { 
            var student = _ctx.Students.FirstOrDefault(s => s.Id == id);
            if (student == null) 
            {
                return NotFound();
            }

            student.IsActive = false;
            await _ctx.SaveChangesAsync();
            return RedirectToAction("Nav", "StudDash");
        }
    }
}
