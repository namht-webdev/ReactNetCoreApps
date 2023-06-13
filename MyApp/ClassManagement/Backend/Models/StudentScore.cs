using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace ClassManagement.Models;
[PrimaryKey(nameof(StudentId), nameof(SubjectId))]
public class StudentScore
{
    [Column(Order = 1)]
    public int StudentId { get; set; }
    [ForeignKey("StudentId")]
    public Student Student { get; set; }
    [Column(Order = 2)]
    public int SubjectId { get; set; }
    [ForeignKey("SubjectId")]
    public Subject Subject { get; set; }
    public double Score { get; set; }
}