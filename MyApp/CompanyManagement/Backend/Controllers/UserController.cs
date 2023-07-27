using Microsoft.AspNetCore.Mvc;
using CompanyManagement.Models;
using CompanyManagement.Data;
using System.IO;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IHostEnvironment _env;

    private readonly IConfiguration _configuration;

    public UserController(IUserRepository userRepository, IHostEnvironment env, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _env = env;
        _configuration = configuration;
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
    public async Task<IActionResult> UploadFile([FromQuery] string userId, [FromForm] IFormFile fileUpload)
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
                var oldPath = Path.Combine(_env.ContentRootPath, string.Concat(@"..\"), "Frontend", @"public\uploads", user.avatar == null ? "" : user.avatar);

                var result = await _userRepository.UpdateAvatar(userId, fileName);
                if (!result) return BadRequest(new { success = false });
                System.IO.File.Delete(oldPath);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await fileUpload.CopyToAsync(stream);
                }

                return Ok(new { success = true });
            }
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Có lỗi từ hệ thống", statusCode = 500 });
        }

        return Ok("No file or empty file provided.");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(string email, string password)
    {
        try
        {
            var authUser = await _userRepository.Login(email, password);
            if (authUser != null)
            {
                var claims = new[]
            {
                new Claim(ClaimTypes.Name, authUser.user_id),
                new Claim(ClaimTypes.Role, authUser.role_id)
                // You can add more claims as needed (e.g., roles, user id, etc.)
                
            };
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!)); // Use the same secret key as above
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var tokenConfig = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"], // Use the same issuer as above
                    audience: _configuration["Jwt:Audience"], // Use the same audience as above
                    claims: claims,
                    expires: DateTime.Now.AddDays(1), // Set the token expiration time
                    signingCredentials: creds
                );

                var token = new JwtSecurityTokenHandler().WriteToken(tokenConfig);
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Expires = DateTime.Now.AddDays(1) // Đặt thời hạn cho cookie
                };
                Response.Cookies.Append("token", token, cookieOptions);
                return Ok(new { success = true, message = "Đăng nhập thành công", user = authUser, token = token });
            }
            return BadRequest(new { success = false, message = "Email hoặc mật khẩu không đúng" });
        }
        catch (System.Exception e)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Có lỗi từ hệ thống", statusCode = 500 });
        }

    }
}