using Microsoft.EntityFrameworkCore;
using Test.API.sample.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region [- AddDbContext() -]
var connectionString = builder.Configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ProjectDbContext>(options => options.UseSqlServer(connectionString));
#endregion
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
