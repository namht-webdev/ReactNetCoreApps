using Microsoft.AspNetCore.Authorization;
namespace ClassManagement.Authorization;
public class MustBeTeacherRequirement : IAuthorizationRequirement
{
    public MustBeTeacherRequirement()
    {
    }
}
