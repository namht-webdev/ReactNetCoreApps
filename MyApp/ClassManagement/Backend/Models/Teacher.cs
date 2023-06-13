namespace ClassManagement.Models;

public class Teacher : Person
{
    public int classId { get; set; }
    public Class Class { get; set; }
    public int? SubjectId { get; set; }
    Subject? Subject { get; set; }
}