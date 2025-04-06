using DeadlineMissed.TaskService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeadlineMissed.TaskService.Infrastructure.Data;

public class AppDbContext: DbContext
{
    public DbSet<TodoTask> Tasks { get; set; }
    public DbSet<TaskAssignment> TaskAssignments { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskAssignment>()
            .HasKey(ta => new { ta.TodoTaskId, ta.UserId });

        modelBuilder.Entity<TaskAssignment>()
            .HasOne(ta => ta.TodoTask)
            .WithMany(t => t.Assignments)
            .HasForeignKey(ta => ta.TodoTaskId);
    }
}
