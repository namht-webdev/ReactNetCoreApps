using Microsoft.EntityFrameworkCore;

namespace ClassManagement.Models;
[PrimaryKey(nameof(StudentId), nameof(SubjectId), nameof(DateAbsent))]
public class Absent
{
    public string StudentId { get; set; }
    public Student Student { get; set; }
    public string SubjectId { get; set; }
    public Subject Subject { get; set; }
    public DateTime DateAbsent { get; set; }
}