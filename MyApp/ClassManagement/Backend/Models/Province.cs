using System.ComponentModel.DataAnnotations;
namespace ClassManagement.Models;

public class Province
{
    [Key]
    public int ProvinceId { get; }
    public string ProvinceName { get; }
    public virtual IEnumerable<District> District { get; }

}