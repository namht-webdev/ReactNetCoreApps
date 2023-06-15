using ClassManagement.Models;
using Microsoft.AspNetCore.Mvc;

namespace ClassManagement.Data;

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
        if (StudentId == null) return Ok(await _studentRepository.ReadStudentsAsync());
        return Ok(await _studentRepository.ReadStudentAsync(StudentId));
    }
    #endregion

    #region Post Student Requests
    [HttpPost]
    public async Task<IActionResult> CreateStudent(Student Student)
    {
        var response = await _studentRepository.CreateAsync(Student);
        return response ? Ok(Student) : BadRequest(new { Message = "Student already exist", Success = false });
    }
    #endregion

    #region Put Student Requests
    [HttpPut]
    public async Task<IActionResult> UpdateStudent(string StudentId, [FromBody] Student Student)
    {
        var response = await _studentRepository.UpdateTeacherAsync(StudentId, Student);
        return response != null ? Ok(Student) : BadRequest(new { Message = "Student does not exist", Success = false });
    }
    #endregion

    #region Delete Student Requests
    [HttpDelete]
    public async Task<IActionResult> DeleteStudent(string StudentId)
    {
        var response = await _studentRepository.DeleteTeacherAsync(StudentId);
        return response ? Ok(new { Message = "Student has been deleted", Success = true }) : BadRequest(new { Message = "Student does not exist", Success = false });
    }
    #endregion

}