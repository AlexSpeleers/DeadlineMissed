using DeadlineMissed.UserService.Application.DTOs;

namespace DeadlineMissed.UserService.Application.Services;

public interface IUserManagementService
{
    Task<List<UserDto>> GetAllUsersAsync();
    Task<UserDto> GetUserByIdAsync(int id);
    Task<int> AddUserAsync(CreateUserDto userDto);
    Task<List<UserDto>> GetUsersByIdsAsync(List<int> ids);
}
