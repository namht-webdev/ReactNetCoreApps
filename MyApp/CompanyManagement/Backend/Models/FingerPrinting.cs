using Microsoft.EntityFrameworkCore;
namespace CompanyManagement.Models;
[PrimaryKey(nameof(user_id), nameof(date))]
public class FingerPrinting
{
    public string user_id { get; set; }
    public User? user { get; set; }
    public DateTime date { get; set; }
    public DateTime comein_time { get; set; }
    public DateTime comeout_time { get; set; }
}