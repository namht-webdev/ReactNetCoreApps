using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyManagement.Models;

public class Schedule
{
    [Key]
    [Unicode(false)]
    [StringLength(32)]
    public string schedule_id { get; set; }
    [Unicode(false)]
    [StringLength(32)]
    public string? user_id { get; set; }
    //[ForeignKey("user_id")]
    //public User? user { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime date { get; set; }
    [StringLength(2048)]
    public string note { get; set; }
    [StringLength(32)]
    public string time_start { get; set; }
    [StringLength(32)]
    public string time_end { get; set; }
}