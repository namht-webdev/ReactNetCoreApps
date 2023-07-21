using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;
namespace CompanyManagement.Models;
public class User
{
    [Key]
    [Unicode(false)]
    [StringLength(32)]
    public string user_id { get; set; }
    [StringLength(256)]
    public string full_name { get; set; }
    [StringLength(256)]
    public string password_hash { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime birth_date { get; set; }
    [StringLength(10)]
    public string gender { get; set; }
    [Unicode(false)]
    [StringLength(32)]
    public string? ward_id { get; set; }
    public string? street { get; set; }
    //[ForeignKey("address_id")]
    //public Address? address { get; set; }
    [Unicode(false)]
    [StringLength(16)]
    public string? phone_number { get; set; }
    [EmailAddress]
    [StringLength(256)]
    public string email { get; set; }
    [StringLength(256)]
    [Unicode(false)]
    public string? avatar { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime date_start { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime date_end { get; set; }
    public double salary { get; set; }
    [Unicode(false)]
    [StringLength(32)]
    public string department_id { get; set; }
    //[ForeignKey("department_id")]
    //public Department? department { get; set; }
    [Unicode(false)]
    [StringLength(32)]
    public string level_id { get; set; }
    //[ForeignKey("level_id")]
    //public Level? level { get; set; }
    [Unicode(false)]
    [StringLength(32)]
    public string role_id { get; set; }
    //[ForeignKey("role_id")]
    //public Role? role { get; set; }
    public bool is_deleted { get; set; }
    //public virtual ICollection<Schedule>? schedules { get; set; }
    //public virtual ICollection<Announcement>? announcements { get; set; }
}