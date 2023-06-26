using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace CompanyManagement.Models;

public class Address
{
    [Key]
    public string address_id { get; set; }
    public string street { get; set; }
    public string ward_id { get; set; }
    [ForeignKey("ward_id")]
    public Ward ward { get; set; }
}