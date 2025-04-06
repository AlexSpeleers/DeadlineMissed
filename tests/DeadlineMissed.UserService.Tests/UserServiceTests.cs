using DeadlineMissed.UserService.Application.Services;
using DeadlineMissed.UserService.Domain.Entities;
using DeadlineMissed.UserService.Infrastructure.Repositories;
using Moq;

namespace DeadlineMissed.UserService.Tests;

[TestFixture]
public class UserServiceTests
{
    private Mock<IUserRepository> _repositoryMock;
    private UserManagementService _service;

    [SetUp]
    public void SetUp()
    {
        _repositoryMock = new Mock<IUserRepository>();
        _service = new UserManagementService(_repositoryMock.Object);
    }

    [Test]
    public async Task GetAllUsersAsync_ReturnsUsers()
    {
        var users = new List<User>
            {
                new User { Id = 1, Username = "user1", Email = "user1@example.com" }
            };
        _repositoryMock.Setup(r => r.GetAllAsync()).ReturnsAsync(users);

        var result = await _service.GetAllUsersAsync();

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result[0].Username, Is.EqualTo("user1"));
    }

    [Test]
    public async Task GetUserByIdAsync_ExistingId_ReturnsUser()
    {
        var user = new User { Id = 1, Username = "user1", Email = "user1@example.com" };
        _repositoryMock.Setup(r => r.GetByIdAsync(1)).ReturnsAsync(user);

        var result = await _service.GetUserByIdAsync(1);

        Assert.That(result, Is.Not.Null);
        Assert.That(result.Id, Is.EqualTo(1));
        Assert.That(result.Username, Is.EqualTo("user1"));
    }

    [Test]
    public void GetUserByIdAsync_NonExistingId_ThrowsException()
    {
        _repositoryMock.Setup(r => r.GetByIdAsync(999)).ReturnsAsync((User)null);

        Assert.ThrowsAsync<Exception>(async () => await _service.GetUserByIdAsync(999));
    }
}
