using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassManagement.Models;

public class Address
{
    [Key]
    public int AddressId { get; set; }
    public int DistrictId { get; set; }
    public District District { get; set; }
    public string Street { get; set; }
    public Student Student { get; set; }
    public string FullAddress()
    {
        return string.Concat(Street, " ", District.DistrictName, " ", District.Province.ProvinceName);
    }
}