using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;
namespace CompanyManagement.Models;

public class Announcement
{
    [Key]
    [StringLength(32)]
    [Unicode(false)]
    public string annc_id { get; set; }
    [Unicode(false)]
    [StringLength(32)]
    public string? department_id { get; set; }
    //[ForeignKey("department_id")]
    //public Department? department { get; set; }
    [Unicode(false)]
    [StringLength(32)]
    public string? user_id { get; set; }
    //[ForeignKey("user_id")]
    //public User? user { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime date { get; set; }
    [StringLength(2048)]
    public string message { get; set; }
}