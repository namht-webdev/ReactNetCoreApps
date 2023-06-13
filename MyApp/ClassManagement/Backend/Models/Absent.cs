using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ClassManagement.Models;

[Keyless]
public class Absent
{

    public int StudentId { get; set; }
    [ForeignKey("StudentId")]
    public Student Student { get; set; }
    public int SubjectId { get; set; }
    [ForeignKey("SubjectId")]
    public Subject Subject { get; set; }
    public DateTime DateAbsent { get; set; }
}