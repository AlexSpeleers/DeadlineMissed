using DeadlineMissed.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeadlineMissed.Infrastructure.Data;

public class AppDbContext:DbContext
{
    public DbSet<TodoTask> Tasks { get; set; }
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}
