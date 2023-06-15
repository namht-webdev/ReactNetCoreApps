using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ClassManagement.Models;

public class Student : Person
{
    [Key]
    [Unicode(false)]
    [StringLength(16, ErrorMessage = "{0} must be at least {2} characters and maximum {1} characters")]
    public string StudentId { get; set; }
    public string? ClassId { get; set; }
    public Class Class { get; set; }
    public virtual ICollection<Absent> Absent { get; set; }
    public virtual ICollection<StudentScore> StudentScore { get; set; }
}