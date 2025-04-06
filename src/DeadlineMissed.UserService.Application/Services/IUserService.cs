using DeadlineMissed.UserService.Application.DTOs;

namespace DeadlineMissed.UserService.Application.Services;

public interface IUserService
{
    Task<List<UserDto>> GetAllUsersAsync();
    Task<UserDto> GetUserByIdAsync(int id);
    Task AddUserAsync(UserDto userDto);
    Task<List<UserDto>> GetUsersByIdsAsync(List<int> ids);
}
