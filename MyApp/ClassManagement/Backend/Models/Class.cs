using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace ClassManagement.Models;

public class Class
{
    [Key]
    [Unicode(false)]
    [StringLength(36, ErrorMessage = "{0} must be at least {2} characters and maximum {1} characters")]
    public string ClassId { get; set; }
    [Required(ErrorMessage = "Class name must not be empty!")]
    [StringLength(100, ErrorMessage = "{2} has maximum length is {1} characters")]
    public string ClassName { get; set; }
    public string? TeacherId { get; set; }
    public Teacher? Teacher { get; set; }
    public string? Description { get; set; }
    public virtual ICollection<SubjectRegistered>? SubjectRegisted { get; set; }
    public virtual ICollection<Student>? Student { get; set; }
}