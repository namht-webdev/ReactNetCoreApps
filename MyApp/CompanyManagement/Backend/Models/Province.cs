using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace CompanyManagement.Models;

public class Province
{
    [Key]
    public string province_id { get; set; }
    public string province_name { get; set; }
    public virtual ICollection<District>? districts { get; set; }
}