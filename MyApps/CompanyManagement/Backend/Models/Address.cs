using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace CompanyManagement.Models;

public class Address
{
    [Key]
    [Unicode(false)]
    [StringLength(32)]
    public string address_id { get; set; }
    [StringLength(100)]
    public string street { get; set; }
    [Unicode(false)]
    [StringLength(32)]
    public string? ward_id { get; set; }
    //[ForeignKey("ward_id")]
    //public Ward ward { get; set; }
}