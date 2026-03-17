using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagementSystem.Models;

[Table("Course")]
public partial class Course
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("couCode")]
    [StringLength(250)]
    [Unicode(false)]
    public string CouCode { get; set; } = null!;

    [Column("couName")]
    [StringLength(250)]
    [Unicode(false)]
    public string CouName { get; set; } = null!;

    [Column("credits")]
    public int Credits { get; set; }

    [Column("isActive")]
    public bool? IsActive { get; set; }

    [InverseProperty("Cou")]
    public virtual ICollection<Enrol> Enrols { get; set; } = new List<Enrol>();
}
