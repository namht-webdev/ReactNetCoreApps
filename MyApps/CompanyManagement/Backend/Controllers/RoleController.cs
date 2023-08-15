using Microsoft.AspNetCore.Mvc;
using CompanyManagement.Models;
using CompanyManagement.Data;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("/api/[controller]")]
[Authorize(Roles = "admin")]
public class RoleController : ControllerBase
{
    private readonly IRoleRepository _role;

    public RoleController(IRoleRepository role) => _role = role;

    [HttpPost]
    public async Task<IActionResult> Add(Role role)
    {
        try
        {
            var result = await _role.Add(role);
            return result == true ? Ok(new { success = true, message = $"Đã thêm mới vai trò {role.role_id}", data = role }) : BadRequest(new { success = false, message = $"Vai trò {role.role_id} đã tồn tại" });
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Có lỗi từ hệ thống" });
        }
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = await _role.GetAll();
            return Ok(new { success = true, message = "Danh sách vai trò nhân viên", data = result });
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Có lỗi từ hệ thống" });
        }
    }

    [HttpGet("{roleId?}")]
    public async Task<IActionResult> GetOne(string roleId)
    {
        try
        {
            var result = await _role.GetOne(roleId);
            return result != null ? Ok(new { success = true, message = $"Thông tin vai trò {roleId}", data = result }) : BadRequest(new { success = false, message = $"Vai trò {roleId} không còn khả dụng" });
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Có lỗi từ hệ thống" });
        }
    }

    [HttpPut("{roleId?}")]
    public async Task<IActionResult> Update([FromRoute] string roleId, [FromBody] Role role)
    {
        try
        {
            var result = await _role.Update(roleId, role);
            return result != null ? Ok(new { success = true, message = $"Cập nhật vai trò {roleId} thành công", data = result }) : BadRequest(new { success = false, message = "Vai trò {roleId} không còn khả dụng" });
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Có lỗi từ hệ thống" });
        }
    }

    [HttpDelete("{roleId}")]
    public async Task<IActionResult> Delete([FromRoute] string roleId)
    {
        try
        {
            var result = await _role.Delete(roleId);
            return result ? Ok(new { success = true, message = $"Đã xóa vai trò {roleId}", data = roleId }) : BadRequest(new { success = false, message = $"Vai trò {roleId} không còn khả dụng" });
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Có lỗi từ hệ thống" });
        }
    }
}