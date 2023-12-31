using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace ClassManagement.Models;

public class Teacher : User
{
    [Key]
    [Unicode(false)]
    [StringLength(36, ErrorMessage = "{0} must be at least {2} characters and maximum {1} characters")]
    public string TeacherId { get; set; }
    public Class? Class { get; set; }
    public SubjectRegistered? SubjectRegisted { get; set; }
}