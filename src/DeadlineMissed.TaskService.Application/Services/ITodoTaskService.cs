using DeadlineMissed.TaskService.Application.DTOs;
using DeadlineMissed.TaskService.Domain.Entities;

namespace DeadlineMissed.TaskService.Application.Services;

public interface ITodoTaskService
{
    Task<List<TodoTaskDto>> GetAllTasksAsync();
    Task<TodoTaskDto> GetTaskByIdAsync(int id);
    Task AddTaskAsync(TodoTaskDto todoTaskDto);
    Task AssignTaskToUserAsync(int taskId, int userId);
    Task UnassignTaskFromUserAsync(int taskId, int userId);
    Task UpdateTaskStatusAsync(int taskId, TodoTaskStatus status);
}
