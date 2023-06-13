using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassManagement.Models;

public class District
{
    [Key]
    public int ProvinceId { get; }
    [ForeignKey("ProvinceId")]
    public Province Province { get; }
    public int DistrictId { get; }
    public string DistrictName { get; }
    public virtual IEnumerable<Address> Address { get; }

}