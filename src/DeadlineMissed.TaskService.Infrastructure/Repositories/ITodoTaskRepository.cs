using DeadlineMissed.TaskService.Domain.Entities;

namespace DeadlineMissed.TaskService.Infrastructure.Repositories;

public interface ITodoTaskRepository
{
    Task<List<TodoTask>> GetAllAsync();
    Task<TodoTask> GetByIdAsync(int id);
    Task AddAsync(TodoTask todoTask);
    Task UpdateAsync(TodoTask todoTask);
    Task AssignUserToTaskAsync(int taskId, int userId);
    Task UnassignUserFromTaskAsync(int taskId, int userId);
}
