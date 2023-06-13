using Microsoft.EntityFrameworkCore;

namespace ClassManagement.Models;
[PrimaryKey(nameof(StudentId), nameof(SubjectId))]
public class StudentScore
{
    public int StudentId { get; set; }
    public Student Student { get; set; }
    public int SubjectId { get; set; }
    public Subject Subject { get; set; }
    public double Score { get; set; }
}