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
            return result == true ? Ok(new { success = true, message = "Thành công", data = role }) : BadRequest(new { success = false, message = "This role is already exists." });
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Something went wrong!" });
        }
    }
    [HttpGet]
    public async Task<IActionResult> GetRole()
    {
        try
        {
            var result = await _role.GetRole();
            return Ok(new { success = true, message = "Get roles successed", data = result });
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Something went wrong!" });
        }
    }

    [HttpGet("{roleId?}")]
    public async Task<IActionResult> GetOneRole(string roleId)
    {
        try
        {
            var result = await _role.GetOneRole(roleId);
            return result != null ? Ok(new { success = true, message = "Get role successfully", data = result }) : BadRequest(new { success = false, message = "Role này chưa có trong hệ thống" });
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Something went wrong!" });
        }
    }

    [HttpPut("{roleId?}")]
    public async Task<IActionResult> UpdateRole([FromRoute] string roleId, [FromBody] Role role)
    {
        try
        {
            var result = await _role.UpdateRole(roleId, role);
            return result != null ? Ok(new { success = true, message = "Role has been updated successfully", data = result }) : BadRequest(new { success = false, message = "Role này đã bị sửa hoặc xóa" });
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Something went wrong!" });
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