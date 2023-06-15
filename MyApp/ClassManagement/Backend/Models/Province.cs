using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ClassManagement.Models;

public class Province
{
    [Key]
    [Unicode(false)]
    [StringLength(36, ErrorMessage = "{0} must be at least {2} characters and maximum {1} characters")]
    public string ProvinceId { get; set; }
    public string ProvinceName { get; set; }
    public virtual ICollection<District> District { get; set; }

}