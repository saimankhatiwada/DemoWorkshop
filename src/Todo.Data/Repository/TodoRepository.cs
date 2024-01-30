using Microsoft.EntityFrameworkCore;

namespace Todo.Data.Repository;
internal sealed class TodoRepository : ITodoRepository
{
    private readonly ApplicationDbContext _dbContext;

    public TodoRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public void Add(Todos.Todo todo)
    {
        _dbContext.Todos.Add(todo);
        _dbContext.SaveChanges();
    }

    public void Delete(Todos.Todo todo)
    {
        _dbContext.Todos.Remove(todo);
        _dbContext.SaveChanges();
    }

    public async Task<IReadOnlyList<Todos.Todo>> GetAllTodoAsync(CancellationToken cancellationToken = default)
    {
        IReadOnlyList<Todos.Todo?> todos = await _dbContext.Todos.ToListAsync();
        return todos!;
    }

    public async Task<Todos.Todo?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        Todos.Todo? todo = await _dbContext.Todos.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return todo!;
    }

    public async Task<bool> SetTodoCompletedAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var todo = await _dbContext.Todos.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        if(todo is not null)
        {
            todo.IsCompleted = true;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        return false;
    }
}
