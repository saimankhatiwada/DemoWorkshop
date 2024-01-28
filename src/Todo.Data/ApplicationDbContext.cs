using Microsoft.EntityFrameworkCore;

namespace Todo.Data;

#pragma warning disable CS8618
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Todos.Todo> Todos { get; set; }
}

#pragma warning restore CS8618