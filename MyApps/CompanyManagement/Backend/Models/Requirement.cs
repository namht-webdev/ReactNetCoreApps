using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CompanyManagement.Models;

public class Requirement
{
    [Key]
    [StringLength(32)]
    public string requirement_id { get; set; }
    [StringLength(32)]
    public string? from_user { get; set; }
    //[ForeignKey("from_user")]

    //public User? sender { get; set; }
    public string? to_user { get; set; }
    //[ForeignKey("to_user")]
    //public User? reciever { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime date { get; set; }
    [StringLength(2048)]
    public string request_message { get; set; }
}