using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyManagement.Models;

public class Requirement
{
    [Key]
    public string requirement_id { get; set; }
    public string from_user { get; set; }
    [ForeignKey("from_user")]

    public User? sender { get; set; }
    public string? to_user { get; set; }
    [ForeignKey("to_user")]
    public User? reciever { get; set; }
    [Column(TypeName = "smalldatetime")]
    public DateTime date { get; set; }
    public string request_message { get; set; }
}