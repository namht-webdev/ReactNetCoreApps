using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace CompanyManagement.Models;
[PrimaryKey(nameof(user_id), nameof(date))]
public class FingerPrinting
{
    [Unicode(false)]
    [StringLength(32)]
    public string user_id { get; set; }
    //[ForeignKey("user_id")]
    //public User? user { get; set; }
    [Column(TypeName = "smalldatetime")]
    public DateTime date { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime comein_time { get; set; }
    [Column(TypeName = "datetime")]
    public DateTime comeout_time { get; set; }
}