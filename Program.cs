using System.Net;
using Models;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

ICollection<Todo> todos = [];

app.MapGet("/", () => "Hello World!");


app.MapPost("/todo", (Todo todo) =>
{
  todos.Add(todo);
  return Results.Created("/todo", new { message = "Todo criado com sucesso!" });
});

app.MapGet("todo/{id}", (int id) =>
{
  return from todo in todos
         where todo.Id == id
         select new
         {
           todo
         };
});

app.MapGet("/todo", () =>
{
  return todos;
});

app.Run();
