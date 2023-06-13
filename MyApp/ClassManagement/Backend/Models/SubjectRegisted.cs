using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace ClassManagement.Models;

[PrimaryKey(nameof(SubjectId), nameof(ClassId), nameof(TeacherId))]
public class SubjectRegisted
{
    [Column(Order = 1)]
    public int SubjectId { get; set; }
    [ForeignKey("SubjectId")]
    Subject Subject { get; set; }
    [Column(Order = 2)]
    public int ClassId { get; set; }
    [ForeignKey("ClassId")]
    public Class Class { get; set; }
    public int TeacherId { get; set; }
    [ForeignKey("TeacherId")]
    public Teacher Teacher { get; set; }
    [Required(ErrorMessage = "Semester cannot be empty!")]
    public int Semester { get; set; }
    public DateTime Year { get; set; }
}