using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagement.Models;

public class Role
{
    [Key]
    [Unicode(false)]
    [StringLength(32)]
    public string role_id { get; set; }
    [StringLength(256)]
    public string role_name { get; set; }
    //public User? user { get; set; }
}