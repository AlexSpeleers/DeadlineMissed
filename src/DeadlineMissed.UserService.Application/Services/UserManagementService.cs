using DeadlineMissed.UserService.Application.DTOs;
using DeadlineMissed.UserService.Domain.Entities;
using DeadlineMissed.UserService.Infrastructure.Repositories;

namespace DeadlineMissed.UserService.Application.Services;

public class UserManagementService : IUserManagementService
{
    private readonly IUserRepository _userRepository;

    public UserManagementService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<List<UserDto>> GetAllUsersAsync()
    {
        var users = await _userRepository.GetAllAsync();
        return users.Select(u => new UserDto
        {
            Id = u.Id,
            Username = u.Username,
            Email = u.Email
        }).ToList();
    }

    public async Task<UserDto> GetUserByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);
        if (user == null) throw new Exception("User not found");
        return new UserDto { Id = user.Id, Username = user.Username, Email = user.Email };
    }

    public async Task<int> AddUserAsync(CreateUserDto userDto)
    {
        var user = new User { Username = userDto.Username, Email = userDto.Email };
        return await _userRepository.AddAsync(user);
    }
    public async Task<List<UserDto>> GetUsersByIdsAsync(List<int> ids)
    {
        var users = await _userRepository.GetByIdsAsync(ids);
        return users.Select(u => new UserDto
        {
            Id = u.Id,
            Username = u.Username,
            Email = u.Email
        }).ToList();
    }
}
