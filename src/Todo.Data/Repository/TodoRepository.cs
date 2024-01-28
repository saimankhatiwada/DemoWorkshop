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
        throw new NotImplementedException();
    }

    public void Delete(Todos.Todo todo)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Todos.Todo>> GetAllTodoAsync(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<Todos.Todo?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        Todos.Todo? todo = await _dbContext.Todos.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return todo!;
    }

    public Task<bool> SetTodoCompletedAsync(Guid id, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}
