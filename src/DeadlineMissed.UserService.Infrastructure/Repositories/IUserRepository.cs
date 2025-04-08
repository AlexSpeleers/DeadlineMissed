using DeadlineMissed.UserService.Domain.Entities;

namespace DeadlineMissed.UserService.Infrastructure.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetAllAsync();
    Task<User> GetByIdAsync(int id);
    Task<int> AddAsync(User user);
    Task<List<User>> GetByIdsAsync(List<int> ids);
}
