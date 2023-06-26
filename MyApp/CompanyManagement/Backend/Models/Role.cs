using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace CompanyManagement.Models;

public class Role
{
    [Key]
    public string role_id { get; set; }
    public string role_name { get; set; }
    public User? user { get; set; }
}