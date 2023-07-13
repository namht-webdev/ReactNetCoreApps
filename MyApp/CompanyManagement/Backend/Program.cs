using CompanyManagement.Data;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);
var CompanyManagementCors = "_CompanyManagementCors";
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(corsoptions =>
{
    corsoptions.AddPolicy(name: CompanyManagementCors, policy =>
    {
        policy.WithOrigins("http://localhost:3000").AllowAnyHeader().AllowAnyMethod();
        policy.WithOrigins("http://localhost:4321").AllowAnyHeader().AllowAnyMethod();
    });
});
builder.Services.AddDbContext<CompanyManagementDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("CompanyManagementDbContext"));
});
builder.Services.AddRepository();

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
