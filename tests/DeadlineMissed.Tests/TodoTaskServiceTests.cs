using DeadlineMissed.Application.Services;
using DeadlineMissed.Domain.Entities;
using DeadlineMissed.Domain.Interfaces;
using Moq;

namespace DeadlineMissed.Tests;

[TestFixture]
public class TodoTaskServiceTests
{
    private Mock<ITodoTaskRepository> _todoTaskRepositoryMock;
    private ITodoTaskService _todoTaskService;

    [SetUp]
    public void SetUp()
    {
        _todoTaskRepositoryMock = new Mock<ITodoTaskRepository>();
        _todoTaskService = new TodoTaskService(_todoTaskRepositoryMock.Object);
    }

    [Test]
    public async Task GetAllTasksAsync_ReturnsListOfTaskDtos()
    {
        // Arrange: Налаштування моків із тестовими даними
        var tasks = new List<TodoTask>
            {
                new TodoTask { Id = 1, Title = "Task 1", Description = "Desc 1", IsCompleted = false },
                new TodoTask { Id = 2, Title = "Task 2", Description = "Desc 2", IsCompleted = true }
            };
        _todoTaskRepositoryMock.Setup(repo => repo.GetAllAsync()).ReturnsAsync(tasks);

        // Act
        var result = await _todoTaskService.GetAllTasksAsync();

        // Assert
        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(2));
        Assert.That(result[0].Title, Is.EqualTo("Task 1"));
    }
}