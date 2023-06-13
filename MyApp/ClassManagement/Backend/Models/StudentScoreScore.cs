using System.ComponentModel.DataAnnotations;
namespace ClassManagement.Models;

public class StudentScore
{
    [Key]
    public int StudentId { get; set; }
    public Student Student { get; set; }
    [Key]
    public int SubjectId { get; set; }
    public Subject Subject { get; set; }
    public double Score { get; set; }
}