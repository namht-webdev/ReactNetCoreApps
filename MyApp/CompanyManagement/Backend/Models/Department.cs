using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagement.Models;

public class Department
{
    [Key]
    [Unicode(false)]
    [StringLength(32)]
    public string department_id { get; set; }
    [StringLength(256)]
    public string department_name { get; set; }
    public byte floor { get; set; }
    //public User? user { get; set; }
    //public virtual ICollection<Announcement>? announcements { get; set; }
}