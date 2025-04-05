using DeadlineMissed.Application.DTOs;
using DeadlineMissed.Domain.Entities;
using DeadlineMissed.Domain.Interfaces;

namespace DeadlineMissed.Application.Services;

public class TodoTaskService : ITodoTaskService
{
    private readonly ITodoTaskRepository _todoTaskRepository;

    public TodoTaskService(ITodoTaskRepository todoTaskRepository) => _todoTaskRepository = todoTaskRepository;

    public async Task AddTaskAsync(TodoTaskDto todoTaskDto)
    {
        var task = new TodoTask { Title = todoTaskDto.Title, Description = todoTaskDto.Description, IsCompleted = todoTaskDto.IsCompleted };
        await _todoTaskRepository.AddAsync(task);
    }

    public async Task<List<TodoTaskDto>> GetAllTasksAsync()
    {
        var tasks = await _todoTaskRepository.GetAllAsync();
        return tasks.Select(t => new TodoTaskDto
        {
            Id = t.Id,
            Title = t.Title,
            Description = t.Description,
            IsCompleted = t.IsCompleted
        }).ToList();
    }

    public async Task<TodoTaskDto> GetTaskByIdAsync(int id)
    {
        var task = await _todoTaskRepository.GetByIdAsync(id);
        if (task == null) throw new Exception("Task not found");
        return new TodoTaskDto { Id = task.Id, Title = task.Title, Description = task.Description, IsCompleted = task.IsCompleted };
    }

    public async Task AssignTaskToUserAsync(int taskId, int userId)
    {
        var task = await _todoTaskRepository.GetByIdAsync(taskId);
        if (task == null) throw new Exception("Task not found");
        await _todoTaskRepository.AssignUserToTaskAsync(taskId, userId);
    }

    public async Task UnassignTaskFromUserAsync(int taskId, int userId)
    {
        var task = await _todoTaskRepository.GetByIdAsync(taskId);
        if (task == null) throw new Exception("Task not found");
        await _todoTaskRepository.UnassignUserFromTaskAsync(taskId, userId);
    }

    public async Task UpdateTaskStatusAsync(int taskId, TodoTaskStatus status)
    {
        var task = await _todoTaskRepository.GetByIdAsync(taskId);
        if (task == null) throw new Exception("Task not found");
        task.Status = status;
        await _todoTaskRepository.UpdateAsync(task);
    }
}