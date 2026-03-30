using SchoolManagementSystem.DTOs;
using SchoolManagementSystem.Models;

namespace SchoolManagementSystem.ViewModels
{
    public class StudentVM
    {
        public IEnumerable<Student>? Students { get; set; }

        public StudDTO? NewStudent { get; set; }
    }
}
