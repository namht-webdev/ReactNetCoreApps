using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace CompanyManagement.Models;

public class Announcement
{
    [Key]
    public string annc_id { get; set; }
    public string? department_id { get; set; }
    public Department? department { get; set; }
    public string? user_id { get; set; }
    public User? user { get; set; }
    public DateTime date { get; set; }
    public string message { get; set; }
}