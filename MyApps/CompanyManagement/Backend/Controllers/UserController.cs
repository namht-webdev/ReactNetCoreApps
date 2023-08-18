using Microsoft.AspNetCore.Mvc;
using CompanyManagement.Models;
using CompanyManagement.Data;
using Microsoft.AspNetCore.Authorization;

[ApiController]
[Route("api/[controller]")]

public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IHostEnvironment _env;

    public UserController(IUserRepository userRepository, IHostEnvironment env)
    {
        _userRepository = userRepository;
        _env = env;
    }
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
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Có lỗi từ hệ thống", statusCode = 500 });
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
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Có lỗi từ hệ thống", statusCode = 500 });
        }
    }
    [HttpGet("{userId}")]
    public async Task<ActionResult> GetOne(string userId)
    {
        try
        {
            var user = await _userRepository.GetOne(userId);
            return user == null ? NotFound(new { success = false, message = "This user is not exists!" }) : Ok(new { success = true, message = $"Thông tin người dùng {userId}", data = user });
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Có lỗi từ hệ thống", statusCode = 500 });
        }
    }

    [HttpPatch("changepassword")]
    public async Task<ActionResult> ChangePassword(string userId, string oldPassword, string newPassword)
    {
        var result = await _userRepository.ChangePassword(userId, oldPassword, newPassword);
        return result ? Ok(new { success = true, message = "Thay đổi mật khảu thành công" }) : BadRequest(new { success = false, message = "mật khẩu cũ không khớp" });
    }

    [HttpDelete("{userId}")]
    public async Task<IActionResult> DeleteUser(string userId)
    {
        bool isSoftDelete = false;
        try
        {
            var result = isSoftDelete ? await _userRepository.SoftDelete(userId) : await _userRepository.HardDelete(userId);
            return result ? Ok(new { success = true, message = "User has been deleted!", data = userId }) : BadRequest(new { success = false, message = $"Người dùng {userId} không còn khả dụng" });
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Có lỗi từ hệ thống", statusCode = 500 });
        }
    }

    [HttpPut("{userId}")]
    public async Task<IActionResult> UpdateUser([FromRoute] string userId, [FromBody] User user)
    {
        try
        {
            var userUpdated = await _userRepository.Update(userId, user);
            return userUpdated != null ? Ok(new { success = true, message = $"Cập nhật thông tin người dùng {userId} thành công", data = userUpdated }) : BadRequest(new { success = false, message = $"Người dùng {userId} không còn khả dụng" });
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Có lỗi từ hệ thống", statusCode = 500 });
        }
    }

    [HttpPost("upload")]
    public async Task<IActionResult> UploadFile([FromQuery] string userId, [FromForm] IFormFile fileUpload, [FromQuery] bool isCreate)
    {
        try
        {
            if (fileUpload != null && fileUpload.Length > 0)
            {
                DateTime currentTime = DateTime.UtcNow;

                // Calculate the number of milliseconds since the Unix epoch (January 1, 1970, 00:00:00 UTC)
                long millisecondsSinceUnixEpoch = (long)(currentTime - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;
                // Create a unique file name to avoid potential conflicts
                var fileName = Path.GetFileName(string.Concat(millisecondsSinceUnixEpoch.ToString(), "_", fileUpload.FileName));

                //var filePath = Path.Combine(_env.ContentRootPath, string.Concat(@"..\", @"Frontend"), @"public\uploads", fileName);.
                var filePath = Path.Combine(_env.ContentRootPath, string.Concat(@"..\"), "Frontend", @"public\uploads", fileName);
                // Save the file to the server
                var user = await _userRepository.GetOne(userId);
                var oldPath = Path.Combine(_env.ContentRootPath, string.Concat(@"..\"), "Frontend", @"public\uploads", string.IsNullOrEmpty(user.avatar) == true ? "" : user.avatar);

                var result = await _userRepository.UpdateAvatar(userId, fileName);
                if (!result) return BadRequest(new { success = false });
                if (!isCreate) System.IO.File.Delete(oldPath);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await fileUpload.CopyToAsync(stream);
                }

                return Ok(new { success = true });
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Có lỗi từ hệ thống", statusCode = 500 });
        }

        return Ok("No file or empty file provided.");
    }

}