using Ef_platzy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddDbContext<Ef_PlatzyContex>(p => p.UseInMemoryDatabase("TaskDB"));
builder.Services.AddSqlServer<Ef_PlatzyContex>("");

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbConection", async ([FromServices] Ef_PlatzyContex dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Database on memory" + dbContext.Database.IsInMemory());
});

app.Run();