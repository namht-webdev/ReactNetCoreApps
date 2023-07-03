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
            return BadRequest(new { success = false, message = "An error occur while processing! Please try again after a second", statusCode = 400 });
        }
    }

    [HttpGet]
    public async Task<ActionResult> GetAllUser()
    {
        try
        {
            var userList = await _userRepository.GetAllUser();
            return Ok(userList);
        }
        catch (System.Exception)
        {
            return Problem(detail: "Internal Server Error", statusCode: StatusCodes.Status500InternalServerError);
        }
    }
    [HttpGet("{userId}")]
    public async Task<ActionResult> GetUser(string userId)
    {
        try
        {
            var user = await _userRepository.GetUser(userId);
            return user == null ? NotFound(new { success = false, message = "This user is not exists!" }) : Ok(user);
        }
        catch (System.Exception)
        {
            return Problem(detail: "Internal Server Error", statusCode: StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPost("changepassword")]
    public async Task<ActionResult> ChangePassword(string userId, string oldPassword, string newPassword)
    {
        var result = await _userRepository.ChangePassword(userId, oldPassword, newPassword);
        return result ? Ok(new { success = true, message = "Your password has been changed" }) : BadRequest(new { success = false, message = "Your old password is not correct" });
    }

    [HttpPost("delete")]
    public async Task<IActionResult> DeleteUser(string userId, bool isSoftDelete)
    {
        try
        {
            var result = isSoftDelete ? await _userRepository.UserSoftDelete(userId) : await _userRepository.UserHardDelete(userId);
            return result ? Ok(new { success = true, message = "User has been deleted!" }) : BadRequest(new { success = false, message = "This user has been deleted before!" });
        }
        catch (System.Exception)
        {
            return Problem(detail: "Internal Server Error", statusCode: StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPut("update")]

    public async Task<IActionResult> UpdateUser([FromQuery] string userId, [FromBody] User user)
    {
        try
        {
            var userUpdated = await _userRepository.UpdateUser(userId, user);
            return userUpdated != null ? Ok(userUpdated) : BadRequest(new { success = false, message = "Seems that user has been deleted!" });
        }
        catch (System.Exception)
        {
            return Problem(detail: "Something went wrong!");
        }
    }
}