using Microsoft.AspNetCore.Mvc;
using CompanyManagement.Models;
using CompanyManagement.Data;

[ApiController]
[Route("/api/[controller]")]
public class ScheduleController : ControllerBase
{
    private readonly IScheduleRepository _schedule;

    public ScheduleController(IScheduleRepository schedule) => _schedule = schedule;

    [HttpPost]
    public async Task<IActionResult> Add(Schedule schedule)
    {
        try
        {
            var result = await _schedule.Add(schedule);
            return result == true ? Ok(new { success = true, message = $"Đã thêm mới lịch trình {schedule.schedule_id}", data = schedule }) : BadRequest(new { success = false, message = $"lịch trình {schedule.schedule_id} đã tồn tại" });
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
            var result = await _schedule.GetAll();
            return Ok(new { success = true, message = "Danh sách lịch trình", data = result });
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Có lỗi từ hệ thống" });
        }
    }

    [HttpGet("{scheduleId?}")]
    public async Task<IActionResult> GetOne(string scheduleId)
    {
        try
        {
            var result = await _schedule.GetOne(scheduleId);
            return result != null ? Ok(new { success = true, message = $"Thông tin lịch trình {scheduleId}", data = result }) : BadRequest(new { success = false, message = $"Lịch trình {scheduleId} không còn khả dụng" });
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Có lỗi từ hệ thống" });
        }
    }

    [HttpPut("{scheduleId?}")]
    public async Task<IActionResult> Update([FromRoute] string scheduleId, [FromBody] Schedule schedule)
    {
        try
        {
            var result = await _schedule.Update(scheduleId, schedule);
            return result != null ? Ok(new { success = true, message = $"Cập nhật lịch trình {scheduleId} thành công", data = result }) : BadRequest(new { success = false, message = $"Lịch trình {scheduleId} không còn khả dụng" });
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Có lỗi từ hệ thống" });
        }
    }

    [HttpDelete("{scheduleId}")]
    public async Task<IActionResult> Delete([FromRoute] string scheduleId)
    {
        try
        {
            var result = await _schedule.Delete(scheduleId);
            return result ? Ok(new { success = true, message = $"Đã xóa lịch trình {scheduleId}", data = scheduleId }) : BadRequest(new { success = false, message = $"Lịch trình {scheduleId} không còn khả dụng" });
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Có lỗi từ hệ thống" });
        }
    }
}