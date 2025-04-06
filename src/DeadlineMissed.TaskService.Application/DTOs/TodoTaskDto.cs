using DeadlineMissed.TaskService.Domain.Entities;

namespace DeadlineMissed.TaskService.Application.DTOs;

public class TodoTaskDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public TodoTaskStatus Status { get; set; }
    public List<int> AssignedUserIds { get; set; } = new();
}
