using DeadlineMissed.Domain.Entities;
using DeadlineMissed.Domain.Interfaces;
using DeadlineMissed.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DeadlineMissed.Infrastructure.Repositories;

public class TodoTaskRepository : ITodoTaskRepository
{
    private readonly AppDbContext _context;
    public TodoTaskRepository(AppDbContext context) => _context = context;

    public async Task AddAsync(TodoTask todoTask)
    {
        _context.Tasks.Add(todoTask);
        await _context.SaveChangesAsync();
    }

    public async Task<List<TodoTask>> GetAllAsync()
    {
        return await _context.Tasks.ToListAsync();
    }

    public async Task<TodoTask> GetByIdAsync(int id)
    {
        return await _context.Tasks.FindAsync(id);
    }
}
