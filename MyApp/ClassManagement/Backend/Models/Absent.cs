using System.ComponentModel.DataAnnotations;
namespace ClassManagement.Models;

public class Absent
{
    [Key]
    public int StudentId { get; set; }
    public Student Student { get; set; }
    [Key]
    public int SubjectId { get; set; }
    public Subject Subject { get; set; }
    [Key]
    public DateTime DateAbsent { get; set; }
}