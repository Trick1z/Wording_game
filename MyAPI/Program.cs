using Domain.Interfaces;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Services.Auth;
using Services.CalculateScore;
using Services.Form;
using Services.Word;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<MYGAMEContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ Register LoginService
//builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IMemberRegisterService,MemberRegisterService>();
builder.Services.AddScoped<IUserRegisterService, UserRegisterService>();
//builder.Services.AddScoped<IUserLoginService, LoginService>();
builder.Services.AddScoped<IUserLoginService, UserLoginService>();
builder.Services.AddScoped<IInsertFormService , InsertFormService>();


builder.Services.AddScoped<CalculateScore>();
builder.Services.AddScoped<WordDataService>();






// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
