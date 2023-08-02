using ClassManagement.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class SubjectRegisteredController : ControllerBase
{
    private readonly ISubjectRegisteredRepository _subjectRegisteredRepository;
    public SubjectRegisteredController(ISubjectRegisteredRepository subjectRegisteredRepository) => _subjectRegisteredRepository = subjectRegisteredRepository;

    #region Post Requests
    [HttpPost]
    public async Task<IActionResult> CreateSubjectRegistered(SubjectRegistered SubjectRegistered)
    {

        try
        {
            bool result = await _subjectRegisteredRepository.CreateSubjectRegisteredAsync(SubjectRegistered);
            return result ? Ok(SubjectRegistered) : BadRequest(new { Message = "This Subject has been registered", Success = false });
        }
        catch (System.Exception)
        {

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPost("list")]
    public async Task<IActionResult> ReadSubjectsRegistered(SubjectRegistered SubjectRegistered)
    {

        try
        {
            var result = await _subjectRegisteredRepository.ReadSubjectsRegisteredAsync(SubjectRegistered);
            return Ok(result);
        }
        catch (System.Exception)
        {

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
    #endregion

    #region Put Requests
    [HttpPut]
    public async Task<IActionResult> UpdateSubjectsRegistered(string SubjectId, int Semester, int Year, SubjectRegistered SubjectRegistered)
    {

        try
        {
            var result = await _subjectRegisteredRepository.UpdateSubjectRegisteredAsync(SubjectId, Semester, Year, SubjectRegistered);
            return result != null ? Ok(SubjectRegistered) : BadRequest(new { Message = "Subject does not exist", Success = false });
        }
        catch (System.Exception)
        {

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
    #endregion
}