using System.ComponentModel.DataAnnotations;

namespace ClassManagement.Models;

public class District
{
    [Key]
    public int ProvinceId { get; }
    public Province Province { get; }
    public int DistrictId { get; }
    public string DistrictName { get; }
    public virtual IEnumerable<Address> Address { get; }

}