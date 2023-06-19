using Microsoft.AspNetCore.Mvc;
using ClassManagement.Data;

[ApiController]
[Route("api/[controller]")]
public class StudentScoreController : ControllerBase
{
    private readonly IStudentScoreRepository _studentScoreRepository;
    public StudentScoreController(IStudentScoreRepository studentScoreRepository) => _studentScoreRepository = studentScoreRepository;
    [HttpGet("{StudentId}")]
    public async Task<IActionResult> GetStudentScoreAllSubject(string StudentId)
    {
        if (string.IsNullOrEmpty(StudentId)) return NotFound();
        var result = await _studentScoreRepository.ReadScoreAllSubjectAsync(StudentId);
        return result == null ? NotFound(new { Message = "This student does not register any subject", Success = false }) : Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetStudentScoreOneSubject(string SubjectId, string StudentId)
    {
        if (string.IsNullOrEmpty(StudentId)) return NotFound();
        var result = await _studentScoreRepository.ReadScoreOneSubjectAsync(SubjectId, StudentId);
        return result == null ? NotFound(new { Message = "This student does not register this subject", Success = false }) : Ok(result);
    }
}