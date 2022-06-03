using Microsoft.EntityFrameworkCore;

namespace TodoAppForAngular.API.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Todo>? Todos { get; set; } 
}