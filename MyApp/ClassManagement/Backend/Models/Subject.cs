using System.ComponentModel.DataAnnotations;
namespace ClassManagement.Models;

public class Subject
{
    [Key]
    public int SubjectId { get; set; }
    public string SubjectName { get; set; }
    public virtual ICollection<SubjectRegisted> SubjectRegisted { get; set; }
    public virtual ICollection<Absent> Absent { get; set; }
}