var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();

