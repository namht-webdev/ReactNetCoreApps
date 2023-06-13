using Microsoft.EntityFrameworkCore;

namespace ClassManagement.Models;
[PrimaryKey(nameof(IdNumber), nameof(SubjectId), nameof(DateAbsent))]
public class Absent
{
    public int IdNumber { get; set; }
    public Student Student { get; set; }
    public int SubjectId { get; set; }
    public Subject Subject { get; set; }
    public DateTime DateAbsent { get; set; }
}