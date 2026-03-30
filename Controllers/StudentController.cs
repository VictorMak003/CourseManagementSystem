using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SchoolManagementSystem.Data;
using SchoolManagementSystem.DTOs;
using SchoolManagementSystem.Models;
using SchoolManagementSystem.ViewModels;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbCtx _ctx;
        private readonly ILogger<StudentController> _logger;
        public StudentController(AppDbCtx ctx, ILogger<StudentController> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }


        [HttpPost]
        public async Task<IActionResult> Create(StudentVM viewModel)
        {
            var student = viewModel.NewStudent;

            if (ModelState.IsValid && student != null)
            {
                bool exists = _ctx.Students.Any(s => s.StudNum == student.StudNum || s.Email == student.Email);
                if (exists)
                {
                    ModelState.AddModelError("Student", "Student Already exists");
                    return View("~/Views/Home/Student.cshtml", viewModel);
                }

                var newStudent = new Student()
                {
                    StudNum = student.StudNum,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    Email = student.Email,
                    DateCreated = DateTime.Now,
                    IsActive = true,
                };

                _ctx.Students.Add(newStudent);
                await _ctx.SaveChangesAsync();
                return RedirectToAction("Student", "Nav");
            }

            ModelState.AddModelError("Student", "Please enter valid details");
            return View("~/Views/Home/Student.cshtml", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(StudentVM viewModel)
        {
            if (!ModelState.IsValid || viewModel.NewStudent == null)
            {
                ModelState.AddModelError("Student", "Please fill all fields");
                _logger.LogInformation("Student not found");
                return View("~/Views/Home/Student.cshtml", viewModel);
            }
            
            var newStudent = viewModel.NewStudent;
            if (newStudent == null)
            {
                _logger.LogInformation("VM Student not found");
                return NotFound();
            }

            var student = await _ctx.Students.FirstOrDefaultAsync(s => s.Id == newStudent.Id);

            if (student == null)
            {
                _logger.LogInformation("DB Student not found");
                return NotFound();
            }

            var update = await TryUpdateModelAsync<Student>(
                student,
                "",
                st => st.StudNum, st => st.FirstName, st => st.LastName, st => st.Email);
            

            student.StudNum = newStudent.StudNum;
            student.FirstName = newStudent.FirstName;
            student.LastName = newStudent.LastName;
            student.Email = newStudent.Email;
            student.DateCreated = student.DateCreated;

            _logger.LogInformation($"Student({student.StudNum}) Updated");
            await _ctx.SaveChangesAsync();
            return RedirectToAction("Student", "Nav");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            var student = _ctx.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            student.IsActive = false;
            await _ctx.SaveChangesAsync();
            return RedirectToAction("Nav", "Student");
        }
    }
}
