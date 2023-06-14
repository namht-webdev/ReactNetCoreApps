using System.ComponentModel.DataAnnotations;
namespace ClassManagement.Models;

public class Province
{
    [Key]
    public int ProvinceId { get; set; }
    public string ProvinceName { get; set; }
    public virtual ICollection<District> District { get; set; }

}