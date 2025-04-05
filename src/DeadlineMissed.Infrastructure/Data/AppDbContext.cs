using DeadlineMissed.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DeadlineMissed.Infrastructure.Data;

public class AppDbContext:DbContext
{
    public DbSet<TodoTask> Tasks { get; set; }
    public DbSet<User> Users { get; set; }
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

        modelBuilder.Entity<TaskAssignment>()
            .HasOne(ta => ta.User)
            .WithMany(u => u.AssignedTasks)
            .HasForeignKey(ta => ta.UserId);
    }
}
