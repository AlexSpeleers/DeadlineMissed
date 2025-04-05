using DeadlineMissed.Domain.Entities;

namespace DeadlineMissed.Domain.Interfaces;

public interface ITodoTaskRepository
{
    Task<List<TodoTask>> GetAllAsync();
    Task<TodoTask> GetByIdAsync(int id);
    Task AddAsync(TodoTask todoTask);
    Task UpdateAsync(TodoTask todoTask);
    Task AssignUserToTaskAsync(int taskId, int userId);
    Task UnassignUserFromTaskAsync(int taskId, int userId);
}
