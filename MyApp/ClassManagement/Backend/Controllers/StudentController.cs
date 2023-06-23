using ClassManagement.Models;
using Microsoft.AspNetCore.Mvc;
using ClassManagement.Data;

[ApiController]
[Route(("api/[controller]"))]
public class StudentController : ControllerBase
{
    private readonly IStudentRepository _studentRepository;
    #region Get Student Requests
    public StudentController(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }
    [HttpGet("{StudentId?}")]
    public async Task<IActionResult> ReadStudent(string? StudentId)
    {
        try
        {
            if (StudentId == null) return Ok(await _studentRepository.ReadStudentsAsync());
            return Ok(await _studentRepository.ReadStudentAsync(StudentId));
        }
        catch (System.Exception)
        {

            return StatusCode(StatusCodes.Status500InternalServerError);
        }

    }
    #endregion

    #region Post Student Requests
    [HttpPost]
    public async Task<IActionResult> CreateStudent(Student Student)
    {
        try
        {
            var response = await _studentRepository.CreateAsync(Student);
            return response ? Ok(Student) : BadRequest(new { Message = "Student already exist", Success = false });
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
    #endregion

    #region Put Student Requests
    [HttpPut]
    public async Task<IActionResult> UpdateStudent(string StudentId, [FromBody] Student Student)
    {
        try
        {
            var response = await _studentRepository.UpdateStudentAsync(StudentId, Student);
            return response != null ? Ok(Student) : BadRequest(new { Message = "Student does not exist", Success = false });
        }
        catch (System.Exception)
        {

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
    #endregion

    #region Delete Student Requests

    [HttpDelete]
    public async Task<IActionResult> DeleteStudent(string StudentId)
    {

        try
        {
            var response = await _studentRepository.DeleteTeacherAsync(StudentId);
            return response ? Ok(new { Message = "Student has been deleted", Success = true }) : BadRequest(new { Message = "Student does not exist", Success = false });
        }
        catch (System.Exception)
        {

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
    #endregion

}