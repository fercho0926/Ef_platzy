using Ef_platzy.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<Ef_PlatzyContex>(p => p.UseInMemoryDatabase("TaskDB"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();