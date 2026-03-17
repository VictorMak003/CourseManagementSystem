using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagementSystem.Models;

[Table("Student")]
public partial class Student
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("studNum")]
    [StringLength(250)]
    [Unicode(false)]
    public string StudNum { get; set; } = null!;

    [Column("firstName")]
    [StringLength(250)]
    [Unicode(false)]
    public string FirstName { get; set; } = null!;

    [Column("lastName")]
    [StringLength(250)]
    [Unicode(false)]
    public string LastName { get; set; } = null!;

    [Column("dateCreated", TypeName = "datetime")]
    public DateTime DateCreated { get; set; }

    [Column("email")]
    [StringLength(250)]
    [Unicode(false)]
    public string Email { get; set; } = null!;

    [Column("isActive")]
    public bool? IsActive { get; set; }

    [InverseProperty("Stud")]
    public virtual ICollection<Enrol> Enrols { get; set; } = new List<Enrol>();
}
