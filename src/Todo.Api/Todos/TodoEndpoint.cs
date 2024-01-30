using Microsoft.AspNetCore.Http.HttpResults;
using Todo.Data.Repository;

namespace Todo.Api.Todos;

public static class TodoEndpoint
{
    public static IEndpointRouteBuilder MapTodo(this IEndpointRouteBuilder routeBuilder)
    {
        RouteGroupBuilder routeGroupBuilder = routeBuilder.MapGroup("/api/todo");

        routeGroupBuilder.MapGet("/all", GetAllTodoAsync);

        routeGroupBuilder.MapPost("/create", CreateTodo);

        routeGroupBuilder.MapPost("/completed", SetTodoCompletedAsync);

        routeGroupBuilder.MapDelete("/delete/{id}", DeleteTodoAsync);

        return routeBuilder;
    }

    public static async Task<Results<Ok<IReadOnlyList<Data.Todos.Todo>>, BadRequest>> GetAllTodoAsync(
        ITodoRepository todoRepository,
        CancellationToken cancellationToken)
    {
        var data = await todoRepository.GetAllTodoAsync(cancellationToken);

        if (data is not null)
        {
            return TypedResults.Ok(data);
        }

        return TypedResults.BadRequest();
    }

    public static Results<Ok, BadRequest> CreateTodo(
        TodoCreateRequest request,
        ITodoRepository todoRepository)
    {
        todoRepository.Add(new Data.Todos.Todo
        {
            Id = Guid.NewGuid(),
            Name = request.name,
            IsCompleted = request.isCompleted
        });

        return TypedResults.Ok();
    }

    public static async Task<Results<Ok, BadRequest>> DeleteTodoAsync(
        Guid id, 
        ITodoRepository todoRepository, 
        CancellationToken cancellationToken)
    {
        var data = await todoRepository.GetByIdAsync(id, cancellationToken);
        if(data is not null)
        {
            todoRepository.Delete(data);

            return TypedResults.Ok();
        }

        return TypedResults.BadRequest();
    }

    public static async Task<Results<Ok, BadRequest>> SetTodoCompletedAsync(
        Guid id, 
        ITodoRepository todoRepository, 
        CancellationToken cancellationToken)
    {
        var result = await todoRepository.SetTodoCompletedAsync(id, cancellationToken);
        if(result)
        {
            return TypedResults.Ok();
        }

        return TypedResults.BadRequest();
    }
}
