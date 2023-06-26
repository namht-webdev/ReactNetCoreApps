using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace CompanyManagement.Models;
public class User
{
    [Key]
    public string user_id { get; set; }
    public string full_name { get; set; }
    public string password_hash { get; set; }
    public DateTime birth_date { get; set; }
    public string gender { get; set; }
    //public string address_id { get; set; }
    //public Address? address { get; set; }
    public string phone_number { get; set; }
    public string email { get; set; }
    public string avatar { get; set; }
    public DateTime date_start { get; set; }
    public DateTime date_end { get; set; }
    public double salary { get; set; }
    public string department_id { get; set; }
    public Department? department { get; set; }
    public string level_id { get; set; }
    public Level? level { get; set; }
    public string role_id { get; set; }
    public Role? role { get; set; }

    public virtual ICollection<Schedule> schedules { get; set; }
    public virtual ICollection<Announcement>? announcements { get; set; }
}