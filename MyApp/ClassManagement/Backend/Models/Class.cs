using System.ComponentModel.DataAnnotations;
namespace ClassManagement.Models;

public class Class
{
    [Key]
    public int ClassId { get; set; }
    [Required(ErrorMessage = "Class name must not be empty!")]
    [StringLength(100, ErrorMessage = "{2} has maximum length is {1} characters")]
    public string ClassName { get; set; }
    [Required(ErrorMessage = "Teacher id must not be empty!")]
    public int TeacherId { get; set; }
    public Teacher Teacher { get; set; }
    public string? Description { get; set; }
    public virtual IEnumerable<SubjectRegisted> SubjectRegisted { get; set; }
    public virtual IEnumerable<Student> Student { get; set; }
}