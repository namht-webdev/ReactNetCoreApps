using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

using ClassManagement.Models;
public abstract class Person
{
    [Required(ErrorMessage = "{0} must not be empty!")]
    [StringLength(255, ErrorMessage = "{2} has maximum length is {1} characters")]
    public string FullName { get; set; }
    public string PasswordHash { get; set; }
    public DateTime DateOfBirth { get; set; }
    [StringLength(10, ErrorMessage = "{2} has maximum length is {1} characters")]
    [Unicode(false)]
    public string Gender { get; set; }
    public string? DistrictId { get; set; }
    public District? District { get; set; }
    public string? Street { get; set; }
    [StringLength(10, ErrorMessage = "Phone Number is invalid!")]
    public string PhoneNumber { get; set; }
    public bool PhoneNumberConfirmed { get; set; } = false;
    [EmailAddress]
    public string? Email { get; set; }
    [Url]
    [StringLength(300, ErrorMessage = "Url is invalid!")]
    public string? Avatar { get; set; }
}