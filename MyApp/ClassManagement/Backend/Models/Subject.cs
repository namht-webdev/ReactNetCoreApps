using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace ClassManagement.Models;

public class Subject
{
    [Key]
    [Unicode(false)]
    [StringLength(36, ErrorMessage = "{0} must be at least {2} characters and maximum {1} characters")]
    public string SubjectId { get; set; }
    public string SubjectName { get; set; }
    public virtual ICollection<SubjectRegisted>? SubjectRegisted { get; set; }
    public virtual ICollection<Absent>? Absent { get; set; }
}