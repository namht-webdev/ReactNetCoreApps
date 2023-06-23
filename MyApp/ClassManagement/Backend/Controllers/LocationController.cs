using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ClassManagement.Data;

[ApiController]
[Route("api/[controller]")]
public class LocationController : ControllerBase
{
    private readonly ClassManagementDbContext _dbContext;
    public LocationController(ClassManagementDbContext dbContext) => _dbContext = dbContext;

    [HttpGet("province")]
    public async Task<IActionResult> GetProvinces()
    {
        try
        {
            var provinces = await _dbContext.Province.ToListAsync();
            return Ok(provinces);
        }
        catch (System.Exception)
        {

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
    [HttpGet("district")]
    public async Task<IActionResult> GetDistricts(string provinceId)
    {
        try
        {
            var districts = await (from d in _dbContext.District where d.ProvinceId == provinceId select d).ToListAsync();
            return Ok(districts);
        }
        catch (System.Exception)
        {

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

    }
}