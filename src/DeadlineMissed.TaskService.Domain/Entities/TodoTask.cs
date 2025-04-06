namespace DeadlineMissed.TaskService.Domain.Entities;

public class TodoTask
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public bool IsCompleted { get; set; }
    public TodoTaskStatus Status { get; set; }
    public List<TaskAssignment> Assignments { get; set; } = new();
}

public enum TodoTaskStatus
{
    Backlog,
    InProgress,
    ReadyToTest,
    InTest,
    Rework,
    Approved
}

public class TaskAssignment
{
    public int TodoTaskId { get; set; }
    public TodoTask TodoTask { get; set; }
    public int UserId { get; set; }
}