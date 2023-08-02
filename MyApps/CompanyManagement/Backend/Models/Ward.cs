using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore;
namespace CompanyManagement.Models;

public class Ward
{
    [Key]
    [Unicode(false)]
    [StringLength(32)]
    public string ward_id { get; set; }
    [StringLength(256)]
    public string ward_name { get; set; }
    [Unicode(false)]
    [StringLength(32)]
    public string district_id { get; set; }
    //[ForeignKey("district_id")]
    //public District? district { get; set; }
    //public Address address { get; set; }
}