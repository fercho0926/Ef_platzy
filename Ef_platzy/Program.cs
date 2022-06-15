using Ef_platzy.Enum;
using Ef_platzy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Task = Ef_platzy.Models.Task;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
;

//builder.Services.AddDbContext<Ef_PlatzyContex>(p => p.UseInMemoryDatabase("TaskDB"));
builder.Services.AddDbContext<Ef_PlatzyContex>(p =>
    p.UseSqlServer(connectionString));
;

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/dbConection", async ([FromServices] Ef_PlatzyContex dbContext) =>
{
    dbContext.Database.EnsureCreated();
    return Results.Ok("Database on memory" + dbContext.Database.IsInMemory());
});

app.MapGet("/api/task",
    async ([FromServices] Ef_PlatzyContex dbContext) =>
    {
        return Results.Ok(dbContext.Tasks.Include(p => p.Category).Where(p => p.priority == Priority.Hight));
    });


app.MapPost("/api/task",
    async ([FromServices] Ef_PlatzyContex dbContext, [FromBody] Task task) =>
    {
        task.TaskId = Guid.NewGuid();
        task.DateCreated = DateTime.Now;
        await dbContext.AddAsync(task);
        await dbContext.SaveChangesAsync();

        return Results.Ok();
    });


app.MapPut("/api/task/{id}",
    async ([FromServices] Ef_PlatzyContex dbContext, [FromBody] Task task, [FromRoute] Guid id) =>
    {
        var find = dbContext.Tasks.Find(id);

        if (find != null)
        {
            find.CategoryId = task.CategoryId;
            find.Title = task.Title;
            find.priority = task.priority;
            find.Description = task.Description;

            await dbContext.SaveChangesAsync();
            return Results.Ok();
        }
        else
        {
            return Results.NotFound();
        }
    });

app.MapDelete("/api/task/{id}",
    async ([FromServices] Ef_PlatzyContex dbContext, [FromRoute] Guid id) =>
    {
        var find = dbContext.Tasks.Find(id);

        if (find != null)
        {
            dbContext.Remove(find);
            await dbContext.SaveChangesAsync();
            return Results.Ok();
        }
        else
        {
            return Results.NotFound();
        }
    });

app.Run();