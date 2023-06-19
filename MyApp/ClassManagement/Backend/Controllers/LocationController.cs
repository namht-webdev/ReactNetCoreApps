using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace ClassManagement.Data;
[ApiController]
[Route("api/[controller]")]
public class LocationController : ControllerBase
{
    private readonly ClassManagementDbContext _dbContext;
    public LocationController(ClassManagementDbContext dbContext) => _dbContext = dbContext;

    [HttpGet("province")]
    public async Task<IActionResult> GetProvinces()
    {
        var provinces = await _dbContext.Province.ToListAsync();
        return Ok(provinces);
    }
    [HttpGet("district")]
    public async Task<IActionResult> GetDistricts(string provinceId)
    {
        var districts = await (from d in _dbContext.District where d.ProvinceId == provinceId select d).ToListAsync();
        return Ok(districts);
    }
}