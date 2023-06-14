using System.ComponentModel.DataAnnotations;
namespace ClassManagement.Models;

public class Teacher : Person
{
    [Key]
    public int TeacherId { get; set; }
    public Class Class { get; set; }
}