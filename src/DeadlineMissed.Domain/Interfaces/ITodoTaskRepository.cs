using DeadlineMissed.Domain.Entities;

namespace DeadlineMissed.Domain.Interfaces;

public interface ITodoTaskRepository
{
    Task<List<TodoTask>> GetAllAsync();
    Task<TodoTask> GetByIdAsync(int id);
    Task AddAsync(TodoTask todoTask);
}
