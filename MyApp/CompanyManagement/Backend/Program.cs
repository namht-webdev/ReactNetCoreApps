using CompanyManagement.Data;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var CompanyManagementCors = "_CompanyManagementCors";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Cors
builder.Services.AddCors(soptions =>
{
    soptions.AddPolicy(name: CompanyManagementCors, policy =>
    {
        policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
        policy.WithOrigins("http://localhost:4321").AllowAnyHeader().AllowAnyMethod();
    });
});

// Database
builder.Services.AddDbContext<CompanyManagementDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CompanyManagementDbContext"));
});

// Data Repository
builder.Services.AddRepository();

// File input
builder.Services.Configure<IISServerOptions>(options =>
{
    options.MaxRequestBodySize = int.MaxValue;
});

builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = int.MaxValue;
});

// Authentication and authorization

builder.Services.AddAuthentication(options =>
{
    // Xác thực yêu cầu: yêu cầu đăng nhập
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    // Yêu cầu xác thực: Đăng nhập sai => chuyển hướng người dùng về trang đăng nhập
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    // // URL của Identity Provider (IdP) hoặc trung tâm xác thực
    // options.Authority = builder.Configuration.GetValue<string>("Auth0:Authority");
    // // định danh của ứng dụng mà token này được tạo ra để sử dụng. IdP sẽ đảm bảo rằng token chỉ có thể được sử dụng bởi ứng dụng với Audience khớp với giá trị này.
    // options.Audience = builder.Configuration.GetValue<string>("Auth0:Audience");
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateIssuerSigningKey = true,
        ValidateLifetime = true,
        ValidIssuer = builder.Configuration.GetValue<string>("Jwt:Issuer"),
        ValidAudience = builder.Configuration.GetValue<string>("Jwt:Audience"),
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration.GetValue<string>("Jwt:Key")!))
    };

});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(CompanyManagementCors);
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
