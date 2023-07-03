using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;
namespace CompanyManagement.Models;

public class Announcement
{
    [Key]
    public string annc_id { get; set; }
    public string? department_id { get; set; }
    [ForeignKey("department_id")]
    public Department? department { get; set; }
    public string? user_id { get; set; }
    [ForeignKey("user_id")]
    public User? user { get; set; }
    [Column(TypeName = "smalldatetime")]
    public DateTime date { get; set; }
    public string message { get; set; }
}