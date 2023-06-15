using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
namespace ClassManagement.Models;

public class District
{
    [Key]
    [Unicode(false)]
    [StringLength(16, ErrorMessage = "{0} must be at least {2} characters and maximum {1} characters")]
    public string DistrictId { get; set; }
    public string DistrictName { get; set; }
    public string ProvinceId { get; set; }
    public Province Province { get; set; }
    public Student Student { get; set; }
}