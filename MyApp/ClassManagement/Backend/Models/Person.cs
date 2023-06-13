using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using ClassManagement.Models;
public abstract class Person
{
    [Key]
    public int IdNumber { get; set; }
    [Required(ErrorMessage = "{0} must not be empty!")]
    [StringLength(255, ErrorMessage = "{2} has maximum length is {1} characters")]
    public string FullName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int AddressId { get; set; }
    public Address Address { get; set; }
    public string PhoneNumber { get; set; }
    public string? Email { get; set; }
    public string? Avatar { get; set; }
}