using Microsoft.AspNetCore.Mvc;
using CompanyManagement.Data;
using CompanyManagement.Models;

[ApiController]
[Route("/api/[controller]")]

public class LevelController : ControllerBase
{
    private readonly ILevelRepository _level;
    public LevelController(ILevelRepository level) => _level = level;

    [HttpPost]
    public async Task<IActionResult> Add(Level level)
    {
        try
        {
            var result = await _level.Add(level);
            return result ? Ok(new { success = true, message = $"Đã thêm mới cấp {level.level_id}", data = level }) : BadRequest(new { success = false, message = $"Cấp {level.level_id} đã tồn tại" });
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
            var result = await _level.GetAll();
            return Ok(new { success = true, message = "Danh sách cấp bậc nhân viên công ty", data = result });
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Có lỗi từ hệ thống" });
        }
    }

    [HttpGet("{levelId}")]
    public async Task<IActionResult> GetOne(string levelId)
    {
        try
        {
            var result = await _level.GetOne(levelId);
            return result != null ? Ok(new { success = true, message = $"Thông tin cấp bậc {levelId}", data = result }) : BadRequest(new { success = true, message = $"Cấp bậc {levelId} không còn khả dụng" });
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Có lỗi từ hệ thống" });
        }
    }

    [HttpPut("{levelId}")]

    public async Task<IActionResult> Update(string levelId, Level level)
    {
        try
        {
            var result = await _level.Update(levelId, level);
            return result != null ? Ok(new { success = true, message = $"Cập nhật thông tin cấp bậc {levelId} thành công", data = result }) : BadRequest(new { success = true, message = $"Cấp bậc {levelId} không còn khả dụng" });
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Có lỗi từ hệ thống" });
        }

    }

    [HttpDelete("{levelId}")]

    public async Task<IActionResult> Delete(string levelId)
    {
        try
        {
            var result = await _level.Delete(levelId);
            return result ? Ok(new { success = true, message = $"Đã xóa cấp bậc {levelId}", data = levelId }) : BadRequest(new { success = true, message = $"Cấp bậc {levelId} không còn khả dụng" });
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Có lỗi từ hệ thống" });
        }
    }
}