using Microsoft.AspNetCore.Mvc;

namespace ClassManagement.Data;

[ApiController]
[Route(("api/[controller]"))]
public class StudentController : ControllerBase
{
    private readonly IStudentRepository _studentRepository;
    public StudentController(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }
    [HttpGet("student")]
    public async Task<IActionResult> ReadStudents()
    {
        var response = await _studentRepository.ReadStudentsAsync();
        return Ok(response);
    }
    [HttpGet("student/{StudentId}")]
    public async Task<IActionResult> ReadStudent(string StudentId)
    {
        return Ok(await _studentRepository.ReadStudentAsync(StudentId));
    }
}