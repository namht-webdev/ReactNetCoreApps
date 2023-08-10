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
public class LoginController : ControllerBase
{
    private readonly IUserRepository _userRepository;

    private readonly IConfiguration _configuration;

    public LoginController(IUserRepository userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
    }
    [HttpPost]
    public async Task<IActionResult> Login(UserLogin user)
    {
        try
        {
            var authUser = await _userRepository.Login(user.email, user.password);
            if (authUser != null)
            {
                var userLogined = new UserLogined()
                {
                    user_id = authUser.user_id,
                    full_name = authUser.full_name,
                    avatar = authUser.avatar == null ? "" : authUser.avatar,
                    department_id = authUser.department_id,
                    role_id = authUser.role_id,
                    level_id = authUser.level_id
                };
                var token = GenerateToken(userLogined);
                return Ok(new { success = true, message = "Đăng nhập thành công", user = userLogined, token = token });
            }
            return BadRequest(new { success = false, message = "Email hoặc mật khẩu không đúng" });
        }
        catch (System.Exception)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { success = false, message = "Có lỗi từ hệ thống", statusCode = 500 });
        }

    }

    private string GenerateToken(UserLogined user)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var tokenKey = Encoding.UTF8.GetBytes(_configuration["JWT:Key"]!);
        var claims = new[]
            {
                new Claim(ClaimTypes.Role, user.role_id)
                // You can add more claims as needed (e.g., roles, user id, etc.)
            };
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Role, user.role_id)
                }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}