using Microsoft.AspNetCore.Mvc;
using CompanyManagement.Models;
using CompanyManagement.Data;

[ApiController]
[Route("/api/[controller]")]
public class RequirementController : ControllerBase
{
    private readonly IRequirementRepository _requirement;

    public RequirementController(IRequirementRepository requirement) => _requirement = requirement;

    [HttpPost]
    public async Task<IActionResult> Add(Requirement requirement)
    {
        try
        {
            var result = await _requirement.Add(requirement);
            return result == true ? Ok(new { success = true, message = $"Đã thêm mới yêu cầu {requirement.requirement_id}", data = requirement }) : BadRequest(new { success = false, message = $"yêu cầu {requirement.requirement_id} đã tồn tại" });
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
            var result = await _requirement.GetAll();
            return Ok(new { success = true, message = "Danh sách yêu cầu", data = result });
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Có lỗi từ hệ thống" });
        }
    }

    [HttpGet("{requirementId?}")]
    public async Task<IActionResult> GetOne(string requirementId)
    {
        try
        {
            var result = await _requirement.GetOne(requirementId);
            return result != null ? Ok(new { success = true, message = $"Thông tin yêu cầu {requirementId}", data = result }) : BadRequest(new { success = false, message = $"yêu cầu {requirementId} không còn khả dụng" });
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Có lỗi từ hệ thống" });
        }
    }

    [HttpPut("{requirementId?}")]
    public async Task<IActionResult> Update([FromRoute] string requirementId, [FromBody] Requirement requirement)
    {
        try
        {
            var result = await _requirement.Update(requirementId, requirement);
            return result != null ? Ok(new { success = true, message = $"Cập nhật yêu cầu {requirementId} thành công", data = result }) : BadRequest(new { success = false, message = "yêu cầu {requirementId} không còn khả dụng" });
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Có lỗi từ hệ thống" });
        }
    }

    [HttpDelete("{requirementId}")]
    public async Task<IActionResult> Delete([FromRoute] string requirementId)
    {
        try
        {
            var result = await _requirement.Delete(requirementId);
            return result ? Ok(new { success = true, message = $"Đã xóa yêu cầu {requirementId}", data = requirementId }) : BadRequest(new { success = false, message = $"yêu cầu {requirementId} không còn khả dụng" });
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Có lỗi từ hệ thống" });
        }
    }
}