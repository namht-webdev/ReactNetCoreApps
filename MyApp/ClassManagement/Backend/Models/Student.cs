namespace ClassManagement.Models;

public class Student : Person
{
    public int ClassId { get; set; }
    public Class Class { get; set; }
    public virtual IEnumerable<Absent> Absent { get; set; }
    public virtual IEnumerable<StudentScore> StudentScore { get; set; }
}