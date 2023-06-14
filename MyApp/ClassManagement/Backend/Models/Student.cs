using System.ComponentModel.DataAnnotations;

namespace ClassManagement.Models;

public class Student : Person
{
    [Key]
    public int StudentId { get; set; }
    public int? ClassId { get; set; }
    public Class Class { get; set; }
    public virtual ICollection<Absent> Absent { get; set; }
    public virtual ICollection<StudentScore> StudentScore { get; set; }
}