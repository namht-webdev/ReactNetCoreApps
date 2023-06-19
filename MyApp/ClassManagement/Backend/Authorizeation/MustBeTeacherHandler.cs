using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using ClassManagement.Data;
namespace ClassManagement.Authorization;

public class MustBeTeacherHandler :
AuthorizationHandler<MustBeTeacherRequirement>
{
    private readonly ITeacherRepository _teacherRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    public MustBeTeacherHandler(
    ITeacherRepository teacherRepository,
    IHttpContextAccessor httpContextAccessor)
    {
        _teacherRepository = teacherRepository;
        _httpContextAccessor = httpContextAccessor;
    }
    protected async override Task
    HandleRequirementAsync(
    AuthorizationHandlerContext context,
    MustBeTeacherRequirement requirement)
    {
        // TODO - check that the user is authenticated
        if (context.User.Identity == null || !context.User.Identity.IsAuthenticated)
        {
            context.Fail();
            return;
        }
        // TODO - get the question id from the request
        // TODO - get the user id from the name identifier claim, userId can be null here
        var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userId == null)
        {
            context.Fail();
            return;
        }
        // TODO - get the teacher from the teacher repository
        var teacher = await _teacherRepository.ReadTeacherAsync(userId);
        if (teacher == null)
        {
            context.Fail();
            return;
        }
        context.Succeed(requirement);
    }
}
