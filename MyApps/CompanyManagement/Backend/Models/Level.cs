using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace CompanyManagement.Models;

public class Level
{
    [Key]
    [StringLength(32)]
    [Unicode(false)]
    public string level_id { get; set; }
    [StringLength(256)]
    public string level_name { get; set; }
    //public User? user { get; set; }
}