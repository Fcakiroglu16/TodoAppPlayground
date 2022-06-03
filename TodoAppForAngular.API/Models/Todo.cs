namespace TodoAppForAngular.API.Models;

public class Todo
{
    public int Id { get; set; }
    public string? Content { get; set; }
    public DateTime Created { get; set; }
    public bool IsCompleted { get; set; }
}