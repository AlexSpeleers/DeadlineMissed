namespace DeadlineMissed.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public List<TaskAssignment> AssignedTasks { get; set; } = new();
}
