using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace CompanyManagement.Models;
[PrimaryKey(nameof(user_id), nameof(date))]
public class FingerPrinting
{
    public string user_id { get; set; }
    [ForeignKey("user_id")]
    public User? user { get; set; }
    [Column(TypeName = "smalldatetime")]
    public DateTime date { get; set; }
    [Column(TypeName = "smalldatetime")]
    public DateTime comein_time { get; set; }
    [Column(TypeName = "smalldatetime")]
    public DateTime comeout_time { get; set; }
}