using Microsoft.AspNetCore.Mvc;
using CompanyManagement.Models;
using CompanyManagement.Data;


[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    public UserController(IUserRepository userRepository) => _userRepository = userRepository;
    [HttpPost]
    public async Task<ActionResult> CreateUser(User user)
    {
        try
        {
            bool success = await _userRepository.CreateUser(user);
            return success ? Ok(new { success = success, user = user }) : BadRequest(new { success = false, message = "This user already exists!" });
        }
        catch (System.Exception)
        {
            return Problem("Internal Server Error", statusCode: 500);
        }

    }
}