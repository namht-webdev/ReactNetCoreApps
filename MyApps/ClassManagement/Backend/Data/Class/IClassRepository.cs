using Microsoft.AspNetCore.Mvc;
using ClassManagement.Models;
namespace ClassManagement.Data;
public interface IClassRepository
{
    Task<bool> CreateClassAsync(Class Class);
    Task<IEnumerable<Class>> ReadClassesAsync();
    Task<Class> ReadClassAsync(string ClassId);
    Task<Class> UpdateClassAsync(string ClassId, Class Class);
    Task<bool> DeleteClassAsync(string ClassId);
}