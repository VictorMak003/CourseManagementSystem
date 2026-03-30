using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolManagementSystem.DTOs
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string CouCode { get; set; } = null!;
        public string CouName { get; set; } = null!;
        public int Credits { get; set; }

    }
}
