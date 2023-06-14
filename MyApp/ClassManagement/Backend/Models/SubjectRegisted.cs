using System.ComponentModel.DataAnnotations;
//using Microsoft.EntityFrameworkCore;
namespace ClassManagement.Models;

//[PrimaryKey(nameof(SubjectId), nameof(ClassId), nameof(TeacherId))]
public class SubjectRegisted
{
    [Key]
    public int SubjectRegistedId { get; set; }
    public int SubjectId { get; set; }
    public Subject Subject { get; set; }
    public int? ClassId { get; set; }
    public Class Class { get; set; }
    public int? TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    [Required(ErrorMessage = "Semester cannot be empty!")]
    public int Semester { get; set; }
    public DateTime Year { get; set; }
}