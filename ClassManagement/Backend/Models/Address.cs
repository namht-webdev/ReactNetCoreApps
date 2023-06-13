using System.ComponentModel.DataAnnotations;
namespace ClassManagement.Models;

public class Address
{
    [Key]
    public int AddressId { get; set; }
    public int DistrictId { get; }
    public District District { get; }
    public string Street { get; }
    public string FullAddress()
    {
        return string.Concat(Street, " ", District.DistrictName, " ", District.Province.ProvinceName);
    }
}