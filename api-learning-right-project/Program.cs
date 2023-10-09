using api_learning_right_project.Interface;
using api_learning_right_project.Models;
using api_learning_right_project.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Life cycle DI
/*builder.Services.AddScoped<IUser, UserService>();*/
builder.Services.AddScoped<IOrder, OrderService>();
builder.Services.AddScoped<IOrderDetail, OrderDetailService>();
builder.Services.AddScoped(typeof(BCSDbContext));


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
