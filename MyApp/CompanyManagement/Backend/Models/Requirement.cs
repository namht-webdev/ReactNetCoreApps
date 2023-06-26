using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;

namespace CompanyManagement.Models;

public class Requirement
{
    [Key]
    public string requirement_id { get; set; }
    [ForeignKey("sender")]
    public string from_user { get; set; }
    public User? sender { get; set; }
    [ForeignKey("reciever")]
    public string to_user { get; set; }
    public User? reciever { get; set; }
    public DateTime date { get; set; }
    public string require_message { get; set; }
}