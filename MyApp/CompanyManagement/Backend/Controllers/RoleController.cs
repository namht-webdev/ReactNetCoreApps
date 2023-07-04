using Microsoft.AspNetCore.Mvc;
using CompanyManagement.Models;
using CompanyManagement.Data;

[ApiController]
[Route("/api/role")]
public class RoleController : ControllerBase
{
    private readonly IRoleRepository _role;

    public RoleController(IRoleRepository role) => _role = role;

    [HttpPost]
    public async Task<IActionResult> CreateRole(Role role)
    {
        try
        {
            var result = await _role.CreateRole(role);
            return result == true ? Ok(role) : BadRequest(new { success = false, message = "This role is already exists." });
        }
        catch (System.Exception)
        {
            return Problem(detail: "Something went wrong!");
        }
    }
    [HttpGet]
    public async Task<IActionResult> GetRole()
    {
        try
        {
            var result = await _role.GetRole();
            return Ok(result);
        }
        catch (System.Exception)
        {
            return Problem(detail: "Something went wrong!");
        }
    }

    [HttpPut]
    public async Task<IActionResult> UpdateRole(string roleId, Role role)
    {
        try
        {
            var result = await _role.UpdateRole(roleId, role);
            return Ok(result);
        }
        catch (System.Exception)
        {
            return Problem(detail: "Something went wrong!");
        }
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteRole(string roleId)
    {
        try
        {
            var result = await _role.DeleteRole(roleId);
            return result ? Ok(new { success = true, message = $"The role {roleId} is deleted" }) : BadRequest(new { success = false, message = $"The role {roleId} does not exist" });
        }
        catch (System.Exception)
        {
            return Problem(detail: "Something went wrong!");
        }
    }
}