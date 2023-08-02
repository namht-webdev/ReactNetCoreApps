using Microsoft.AspNetCore.Mvc;
using CompanyManagement.Data;
using CompanyManagement.Models;

[ApiController]
[Route("api/[controller]")]

public class DepartmentController : ControllerBase
{
    private readonly IDepartmentRepository _department;
    public DepartmentController(IDepartmentRepository department) => _department = department;

    [HttpPost]
    public async Task<IActionResult> Add(Department department)
    {
        try
        {
            var result = await _department.Add(department);
            return result == true ? Ok(new { success = true, message = $"Đã thêm mới phòng {department.department_id}", data = department }) : BadRequest(new { success = false, message = $"Phòng ban {department.department_id} đã tồn tại." });
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Có lỗi từ hệ thống" });
            ;
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = await _department.GetAll();
            return Ok(new { success = true, message = "Danh sách bộ phận của công ty", data = result });
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Có lỗi từ hệ thống" });
        }
    }

    [HttpPut("{departmentId?}")]
    public async Task<IActionResult> Update([FromRoute] string departmentId, [FromBody] Department department)
    {
        try
        {
            var result = await _department.Update(departmentId, department);
            return result != null ? Ok(new { success = true, message = $"Cập nhật thông tin phòng ban {departmentId} thành công", data = result }) : BadRequest(new { success = false, message = $"Phòng ban {departmentId} không còn khả dụng" });
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Có lỗi từ hệ thống!" });
        }
    }

    [HttpGet("{departmentId?}")]
    public async Task<IActionResult> GetOne(string departmentId)
    {
        try
        {
            var result = await _department.GetOne(departmentId);
            return result != null ? Ok(new { success = true, message = $"Thông tin vai trò {departmentId}", data = result }) : BadRequest(new { success = false, message = $"Phong ban {departmentId} không còn khả dụng" });
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Có lỗi từ hệ thống" });
        }
    }

    [HttpDelete("{departmentId}")]
    public async Task<IActionResult> Delete([FromRoute] string departmentId)
    {
        try
        {
            var result = await _department.Delete(departmentId);
            return result ? Ok(new { success = true, message = $"Đã xóa phòng ban {departmentId}", data = departmentId }) : BadRequest(new { success = false, message = $"Vai trò {departmentId} không còn khả dụng" });
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Có lỗi từ hệ thống" });
        }
    }
}