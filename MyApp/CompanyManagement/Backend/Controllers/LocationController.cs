using Microsoft.AspNetCore.Mvc;
using CompanyManagement.Data;

[ApiController]
[Route("api/[controller]")]
public class LocationController : ControllerBase
{
    private readonly ILocationRepository _location;
    public LocationController(ILocationRepository location) => _location = location;
    [HttpGet("province")]
    public async Task<IActionResult> GetProvince()
    {
        try
        {
            var result = await _location.GetProvince();
            return Ok(new { success = true, message = "Danh sách tỉnh thành Việt Nam", data = result });
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Có lỗi từ hệ thống" });
        }
    }
    [HttpGet("district/{provinceId}")]
    public async Task<IActionResult> GetDistrict(string provinceId)
    {
        try
        {
            var result = await _location.GetDistrict(provinceId);
            return Ok(new { success = true, message = "Danh quận huyện", data = result });
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Có lỗi từ hệ thống" });
        }
    }
    [HttpGet("ward/{districtId}")]
    public async Task<IActionResult> GetWard(string districtId)
    {
        try
        {
            var result = await _location.GetWard(districtId);
            return Ok(new { success = true, message = "Danh sách phường xã", data = result });
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Có lỗi từ hệ thống" });
        }
    }
    [HttpGet("ward")]
    public async Task<IActionResult> GetLocation([FromQuery] string wardId)
    {
        try
        {
            var result = await _location.GetLocation(wardId);
            return Ok(new { success = true, message = "Thông tin địa chỉ", data = result });
        }
        catch (System.Exception)
        {

            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Có lỗi từ hệ thống" });
        }
    }
}