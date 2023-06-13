using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassManagement.Models;

public class Address
{
    [Key]
    public int AddressId { get; set; }
    public int DistrictId { get; }
    [ForeignKey("DistrictId")]
    public District District { get; }
    public string Street { get; }
    public string FullAddress()
    {
        return string.Concat(Street, " ", District.DistrictName, " ", District.Province.ProvinceName);
    }
}