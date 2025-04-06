using DeadlineMissed.TaskService.Application.Services;
using DeadlineMissed.TaskService.Domain.Entities;
using DeadlineMissed.TaskService.Infrastructure.Repositories;
using Moq;

namespace DeadlineMissed.TaskService.Tests;

[TestFixture]
public class TodoTaskServiceTests
{
    private Mock<ITodoTaskRepository> _repositoryMock;
    private Mock<IHttpClientFactory> _httpClientFactoryMock;
    private TodoTaskService _service;

    [SetUp]
    public void SetUp()
    {
        _repositoryMock = new Mock<ITodoTaskRepository>();
        _httpClientFactoryMock = new Mock<IHttpClientFactory>();

        var client = new HttpClient(new MockHttpMessageHandler());
        _httpClientFactoryMock.Setup(f => f.CreateClient("UserService")).Returns(client);

        _service = new TodoTaskService(_repositoryMock.Object, _httpClientFactoryMock.Object);
    }

    [Test]
    public async Task GetAllTasksAsync_ReturnsTasks()
    {
        var tasks = new List<TodoTask>
            {
                new TodoTask
                {
                    Id = 1,
                    Title = "Test",
                    Assignments = new List<TaskAssignment> { new TaskAssignment { UserId = 1 } }
                }
            };
        _repositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(tasks);

        var result = await _service.GetAllTasksAsync();

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result[0].Title, Is.EqualTo("Test"));
        Assert.That(result[0].AssignedUserIds, Contains.Item(1));
    }
}

public class MockHttpMessageHandler : HttpMessageHandler
{
    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        var response = new HttpResponseMessage(System.Net.HttpStatusCode.OK)
        {
            Content = new StringContent("[]")
        };
        return Task.FromResult(response);
    }
}
