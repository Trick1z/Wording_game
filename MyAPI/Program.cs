using Domain.Interfaces;
using Domain.Models;
using FMS.Server.Handlers;
using Microsoft.EntityFrameworkCore;
//using Services.CalculateScore;
//using Services.Form;
using Services.Implements.Auth;
using Services.Word;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MYGAMEContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ Register LoginService
//builder.Services.AddScoped<ILoginService, LoginService>();
//builder.Services.AddScoped<ILoginService, LoginService>();
//builder.Services.AddScoped<IMemberRegisterService,MemberRegisterService>();
//builder.Services.AddScoped<IUserRegisterService, UserRegisterService>();
////builder.Services.AddScoped<IUserLoginService, LoginService>();
//builder.Services.AddScoped<IUserLoginService, UserLoginService>();
//builder.Services.AddScoped<IInsertFormService , InsertFormService>();


//builder.Services.AddScoped<CalculateScore>();
//builder.Services.AddScoped<WordDataService>();

var interfaceAssembly = Assembly.GetAssembly(typeof(ILoginService)).GetTypes().Where(x => x.Name.EndsWith("Service"));
var assembly = Assembly.GetAssembly(typeof(LoginService)).GetTypes().Where(x => x.Name.EndsWith("Service"));
foreach (var @interface in interfaceAssembly)
{
    var interfaceName = @interface.Name;
    var implement = assembly.FirstOrDefault(c => c.IsClass && interfaceName.Substring(1) == c.Name);
    if (implement != null)
        builder.Services.AddScoped(@interface, implement);

}








// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseGlobalExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
