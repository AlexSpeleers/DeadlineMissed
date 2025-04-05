using DeadlineMissed.Application.DTOs;

namespace DeadlineMissed.Application.Services;

public interface ITodoTaskService
{
    Task<List<TodoTaskDto>> GetAllTasksAsync();
    Task<TodoTaskDto> GetTaskByIdAsync(int id);
    Task AddTaskAsync(TodoTaskDto todoTaskDto);
}
