using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassManagement.Models;

public class District
{
    [Key]
    public int DistrictId { get; set; }
    public string DistrictName { get; set; }
    public int ProvinceId { get; set; }
    public Province Province { get; set; }
    public Student Student { get; set; }
}