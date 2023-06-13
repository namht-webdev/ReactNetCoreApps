using System.ComponentModel.DataAnnotations;

namespace ClassManagement.Models;

public class SubjectRegisted
{
    [Key]
    public int SubjectId { get; set; }
    Subject Subject { get; set; }
    [Key]
    public int ClassId { get; set; }
    public Class Class { get; set; }
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    [Required(ErrorMessage = "Semester cannot be empty!")]
    public int Semester { get; set; }
    public DateTime Year { get; set; }
}