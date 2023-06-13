using Microsoft.AspNetCore.Mvc;
using ClassManagement.Models;
namespace ClassManagement.Data;
public interface IClassRepository
{
    Task<bool> CreateAsync(Class myclass);
    Task<IActionResult> ReadAsync(int id);
    Task<IActionResult> UpdateAsync(int id, Class myclass);
    Task<bool> DeleteAsync(int id);
}