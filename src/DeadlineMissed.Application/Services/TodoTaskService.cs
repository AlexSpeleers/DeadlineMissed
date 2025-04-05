using DeadlineMissed.Application.DTOs;
using DeadlineMissed.Domain.Entities;
using DeadlineMissed.Domain.Interfaces;

namespace DeadlineMissed.Application.Services;

public class TodoTaskService : ITodoTaskService
{
    private readonly ITodoTaskRepository _taskRepository;

    public TodoTaskService(ITodoTaskRepository taskRepository) => _taskRepository = taskRepository;

    public async Task AddTaskAsync(TodoTaskDto todoTaskDto)
    {
        var task = new TodoTask { Title = todoTaskDto.Title, Description = todoTaskDto.Description, IsCompleted = todoTaskDto.IsCompleted };
        await _taskRepository.AddAsync(task);
    }

    public async Task<List<TodoTaskDto>> GetAllTasksAsync()
    {
        var tasks = await _taskRepository.GetAllAsync();
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
        var task = await _taskRepository.GetByIdAsync(id);
        if (task == null) throw new Exception("Task not found");
        return new TodoTaskDto { Id = task.Id, Title = task.Title, Description = task.Description, IsCompleted = task.IsCompleted };
    }
}