using System.ComponentModel.DataAnnotations.Schema;
namespace ClassManagement.Models;

public class Student : Person
{
    public int ClassId { get; set; }
    [ForeignKey("ClassId")]
    public Class Class { get; set; }
    public virtual IEnumerable<Absent> Absent { get; set; }
    public virtual IEnumerable<StudentScore> StudentScore { get; set; }
}