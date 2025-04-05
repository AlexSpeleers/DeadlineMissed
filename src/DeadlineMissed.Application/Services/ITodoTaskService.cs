using DeadlineMissed.Application.DTOs;
using DeadlineMissed.Domain.Entities;

namespace DeadlineMissed.Application.Services;

public interface ITodoTaskService
{
    Task<List<TodoTaskDto>> GetAllTasksAsync();
    Task<TodoTaskDto> GetTaskByIdAsync(int id);
    Task AddTaskAsync(TodoTaskDto todoTaskDto);
    Task AssignTaskToUserAsync(int taskId, int userId);
    Task UnassignTaskFromUserAsync(int taskId, int userId);
    Task UpdateTaskStatusAsync(int taskId, TodoTaskStatus status);
}
