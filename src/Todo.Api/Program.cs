using Todo.Api.Todos;
using Todo.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDatabase(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "todo API v1");
        c.RoutePrefix= string.Empty;
    });
}

app.MapGet("/hello", () => {
    return "Hello World!";
});

app.MapTodo();

app.Run();

