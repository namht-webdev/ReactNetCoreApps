using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;
namespace CompanyManagement.Models;

public class Ward
{
    [Key]
    public string ward_id { get; set; }
    public string ward_name { get; set; }
    public string ward_name2 { get; set; }
    public string district_id { get; set; }
    [ForeignKey("district_id")]
    public District? district { get; set; }
    public Address address { get; set; }
}