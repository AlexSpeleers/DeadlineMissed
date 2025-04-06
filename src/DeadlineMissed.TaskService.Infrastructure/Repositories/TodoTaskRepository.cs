using DeadlineMissed.TaskService.Domain.Entities;
using DeadlineMissed.TaskService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DeadlineMissed.TaskService.Infrastructure.Repositories;

public class TodoTaskRepository : ITodoTaskRepository
{
    private readonly AppDbContext _context;
    public TodoTaskRepository(AppDbContext context) => _context = context;

    public async Task AddAsync(TodoTask todoTask)
    {
        _context.Tasks.Add(todoTask);
        await _context.SaveChangesAsync();
    }

    public async Task<List<TodoTask>> GetAllAsync() => await _context.Tasks.ToListAsync();

    public async Task<TodoTask> GetByIdAsync(int id) => await _context.Tasks.FindAsync(id);

    public async Task AssignUserToTaskAsync(int taskId, int userId)
    {
        var assignment = new TaskAssignment { TodoTaskId = taskId, UserId = userId };
        _context.TaskAssignments.Add(assignment);
        await _context.SaveChangesAsync();
    }

    public async Task UnassignUserFromTaskAsync(int taskId, int userId)
    {
        var assignment = await _context.TaskAssignments
            .FirstOrDefaultAsync(ta => ta.TodoTaskId == taskId && ta.UserId == userId);
        if (assignment != null)
        {
            _context.TaskAssignments.Remove(assignment);
            await _context.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(TodoTask todoTask)
    {
        _context.Tasks.Update(todoTask);
        await _context.SaveChangesAsync();
    }
}