namespace Todo.Data.Todos;

#pragma warning disable CS8618
public class Todo
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public bool IsCompleted { get; set; }
}

#pragma warning restore CS8618