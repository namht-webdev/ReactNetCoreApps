using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyManagement.Models;

public class Schedule
{
    [Key]
    public string schedule_id { get; set; }
    public string user_id { get; set; }
    [ForeignKey("user_id")]
    public User? user { get; set; }
    public DateTime date { get; set; }
    public string note { get; set; }
    public string time_start { get; set; }
    public string time_end { get; set; }
}