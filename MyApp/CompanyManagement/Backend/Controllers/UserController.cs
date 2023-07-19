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
    public async Task<ActionResult> Add(User user)
    {
        try
        {
            bool success = await _userRepository.Add(user);
            return success ? Ok(new { success = success, message = $"Đã thêm mới người dùng {user.user_id}", data = user }) : BadRequest(new { success = false, message = $"Người dùng {user.user_id} đã tồn tại" });
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Có lỗi từ hệ thống", statusCode = 400 });
        }
    }

    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        try
        {
            var userList = await _userRepository.GetAll();
            return Ok(new { success = true, message = "Danh sách người dùng", data = userList });
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Có lỗi từ hệ thống", statusCode = 400 });
        }
    }
    [HttpGet("{userId}")]
    public async Task<ActionResult> GetOne(string userId)
    {
        try
        {
            var user = await _userRepository.GetOne(userId);
            return user == null ? NotFound(new { success = false, message = "This user is not exists!" }) : Ok(user);
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Có lỗi từ hệ thống", statusCode = 400 });
        }
    }

    [HttpPatch("changepassword")]
    public async Task<ActionResult> ChangePassword(string userId, string oldPassword, string newPassword)
    {
        var result = await _userRepository.ChangePassword(userId, oldPassword, newPassword);
        return result ? Ok(new { success = true, message = "Thay đổi mật khảu thành công" }) : BadRequest(new { success = false, message = "mật khẩu cũ không khớp" });
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> DeleteUser(string userId, bool isSoftDelete)
    {
        try
        {
            var result = isSoftDelete ? await _userRepository.SoftDelete(userId) : await _userRepository.HardDelete(userId);
            return result ? Ok(new { success = true, message = "User has been deleted!" }) : BadRequest(new { success = false, message = $"Người dùng {userId} không còn khả dụng" });
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Có lỗi từ hệ thống", statusCode = 400 });
        }
    }

    [HttpPut("update")]

    public async Task<IActionResult> UpdateUser([FromQuery] string userId, [FromBody] User user)
    {
        try
        {
            var userUpdated = await _userRepository.Update(userId, user);
            return userUpdated != null ? Ok(userUpdated) : BadRequest(new { success = false, message = $"Người dùng {userId} không còn khả dụng" });
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Có lỗi từ hệ thống", statusCode = 400 });
        }
    }
}