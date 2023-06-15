using Microsoft.EntityFrameworkCore;

namespace ClassManagement.Models;
[PrimaryKey(nameof(StudentId), nameof(SubjectId))]
public class StudentScore
{
    public string StudentId { get; set; }
    public Student Student { get; set; }
    public string SubjectId { get; set; }
    public Subject Subject { get; set; }
    public double Score { get; set; }
}