using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace CompanyManagement.Models;

public class Level
{
    [Key]
    public string level_id { get; set; }
    public string level_name { get; set; }
    public string user_id { get; set; }
    public User? user { get; set; }
}