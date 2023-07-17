using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace CompanyManagement.Models;

public class District
{
    [Key]
    public string district_id { get; set; }
    public string district_name { get; set; }
    public string province_id { get; set; }
    [ForeignKey("province_id")]
    public Province? province { get; set; }
    public virtual ICollection<Ward> wards { get; set; }
}