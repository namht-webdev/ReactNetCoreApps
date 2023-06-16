using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace ClassManagement.Models;

[PrimaryKey(nameof(SubjectId), nameof(Semester), nameof(Year))]
public class SubjectRegistered
{
    public string SubjectId { get; set; }
    public Subject? Subject { get; set; }
    public string? ClassId { get; set; }
    public Class? Class { get; set; }
    public string? TeacherId { get; set; }
    public Teacher? Teacher { get; set; }
    [Required(ErrorMessage = "Semester cannot be empty!")]
    public int Semester { get; set; }
    [Required(ErrorMessage = "Year cannot be empty!")]
    public int Year { get; set; }
}