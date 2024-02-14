using Emp.Librarary.Application.IRepository;
using Emp.Librarary.Application.IServices;
using Emp.Librarary.Application.Services.impl;
using Emp.Librarary.Infrastruture.DataBaseContext;
using Emp.Librarary.Infrastruture.IRepo.Impl;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEmployeeServices, IEmployeeServicesImpl>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepoImpl>();

builder.Services.AddScoped<IUserServices, UserServiceImpl>();
builder.Services.AddScoped<IUserRepository, UserRepositoryImpl>();


builder.Services.AddDbContext<DbaseContext>(
        options => options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=EmployeeDb;Trusted_Connection=True;"));
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
