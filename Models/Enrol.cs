using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagementSystem.Models;

[Table("Enrol")]
public partial class Enrol
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("studId")]
    public int StudId { get; set; }

    [Column("couId")]
    public int CouId { get; set; }

    [Column("dateCreated", TypeName = "datetime")]
    public DateTime DateCreated { get; set; }

    [ForeignKey("CouId")]
    [InverseProperty("Enrols")]
    public virtual Course Cou { get; set; } = null!;

    [ForeignKey("StudId")]
    [InverseProperty("Enrols")]
    public virtual Student Stud { get; set; } = null!;
}
