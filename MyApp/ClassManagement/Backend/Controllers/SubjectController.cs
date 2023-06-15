using ClassManagement.Data;
using ClassManagement.Models;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class SubjectController : ControllerBase
{
    private readonly ISubjectRepository _subjectRepository;
    #region Get Subject Requests
    public SubjectController(ISubjectRepository subjectRepository)
    {
        _subjectRepository = subjectRepository;
    }
    [HttpGet("{SubjectId?}")]
    public async Task<IActionResult> ReadSubject(string? SubjectId)
    {
        if (SubjectId == null) return Ok(await _subjectRepository.ReadSubjectsAsync());
        return Ok(await _subjectRepository.ReadSubjectAsync(SubjectId));
    }
    #endregion

    #region Post Subject Requests
    [HttpPost]
    public async Task<IActionResult> CreateSubject(Subject Subject)
    {
        var response = await _subjectRepository.CreateSubjectAsync(Subject);
        return response ? Ok(Subject) : BadRequest(new { Message = "Subject already exist", Success = false });
    }
    #endregion

    #region Put Subject Requests
    [HttpPut]
    public async Task<IActionResult> UpdateSubject(string SubjectId, [FromBody] Subject Subject)
    {
        var response = await _subjectRepository.UpdateSubjectAsync(SubjectId, Subject);
        return response != null ? Ok(Subject) : BadRequest(new { Message = "Subject does not exist", Success = false });
    }
    #endregion

    #region Delete Subject Requests
    [HttpDelete]
    public async Task<IActionResult> DeleteSubject(string SubjectId)
    {
        var response = await _subjectRepository.DeleteSubjectAsync(SubjectId);
        return response ? Ok(new { Message = "Subject has been deleted", Success = true }) : BadRequest(new { Message = "Subject does not exist", Success = false });
    }
    #endregion
}