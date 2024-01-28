namespace Todo.Data.Repository;

public interface ITodoRepository
{
    Task<Todos.Todo?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<Todos.Todo>> GetAllTodoAsync(CancellationToken cancellationToken = default);
    Task<bool> SetTodoCompletedAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(Todos.Todo todo);
    void Delete(Todos.Todo todo);
}
