using ClassManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ClassManagement.Data;

[ApiController]
[Authorize]
[Route(("api/[controller]"))]
public class TeacherController : ControllerBase
{
    private readonly ITeacherRepository _teacherRepository;
    #region Get Teacher Requests
    public TeacherController(ITeacherRepository teacherRepository)
    {
        _teacherRepository = teacherRepository;
    }
    [HttpGet("{TeacherId?}")]
    public async Task<IActionResult> ReadTeacher(string? TeacherId)
    {

        try
        {
            if (TeacherId == null) return Ok(await _teacherRepository.ReadTeachersAsync());
            return Ok(await _teacherRepository.ReadTeacherAsync(TeacherId));
        }
        catch (System.Exception)
        {

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
    #endregion

    #region Post Teacher Requests
    [HttpPost]
    public async Task<IActionResult> CreateTeacher(Teacher Teacher)
    {

        try
        {
            var response = await _teacherRepository.CreateTeacherAsync(Teacher);
            return response ? Ok(Teacher) : BadRequest(new { Message = "Teacher already exist", Success = false });
        }
        catch (System.Exception)
        {

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
    #endregion

    #region Put Teacher Requests
    [HttpPut]
    public async Task<IActionResult> UpdateTeacher(string TeacherId, [FromBody] Teacher Teacher)
    {

        try
        {
            var response = await _teacherRepository.UpdateTeacherAsync(TeacherId, Teacher);
            return response != null ? Ok(Teacher) : BadRequest(new { Message = "Teacher does not exist", Success = false });
        }
        catch (System.Exception)
        {

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
    #endregion

    #region Delete Teacher Requests
    [HttpDelete]
    public async Task<IActionResult> DeleteTeacher(string TeacherId)
    {

        try
        {
            var response = await _teacherRepository.DeleteTeacherAsync(TeacherId);
            return response ? Ok(new { Message = "Teacher has been deleted", Success = true }) : BadRequest(new { Message = "Teacher does not exist", Success = false });
        }
        catch (System.Exception)
        {

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
    #endregion

}