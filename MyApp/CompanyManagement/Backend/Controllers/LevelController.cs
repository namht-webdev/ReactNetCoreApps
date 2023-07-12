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
    public async Task<IActionResult> Create(Level level)
    {
        try
        {
            var result = await _level.Create(level);
            return result ? Ok(new { success = true, message = "Level created successfully!", data = level }) : BadRequest(new { success = false, message = "This level is already exists" });
        }
        catch (System.Exception)
        {

            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Server error" });
        }
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = await _level.GetAll();
            return Ok(new { success = true, message = "List of levels", data = result });
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Server error" });
        }
    }

    [HttpGet("{levelId}")]
    public async Task<IActionResult> GetOne(string levelId)
    {
        try
        {
            var result = await _level.GetOne(levelId);
            return result != null ? Ok(new { success = true, message = $"Get level {levelId} successfully", data = result }) : BadRequest(new { success = true, message = $"Level {levelId} does not exists" });
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Server error" });
        }
    }

    [HttpPut("{levelId}")]

    public async Task<IActionResult> Update(string levelId, Level level)
    {
        try
        {
            var result = await _level.Update(levelId, level);
            return result != null ? Ok(new { success = true, message = $"Update level {levelId} successfully", data = result }) : BadRequest(new { success = true, message = $"Level {levelId} does not exists" });
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Server error" });
        }

    }

    [HttpDelete("{levelId}")]

    public async Task<IActionResult> Delete(string levelId)
    {
        try
        {
            var result = await _level.Delete(levelId);
            return result ? Ok(new { success = true, message = $"Get level {levelId} successfully", data = levelId }) : BadRequest(new { success = true, message = $"Level {levelId} does not exists" });
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Server error" });
        }
    }
}