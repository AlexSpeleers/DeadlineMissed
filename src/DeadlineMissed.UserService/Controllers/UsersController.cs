using DeadlineMissed.UserService.Application.DTOs;
using DeadlineMissed.UserService.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeadlineMissed.UserService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserManagementService _userService;

    public UsersController(IUserManagementService userService) => _userService = userService;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAllUsersAsync();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userService.GetUserByIdAsync(id);
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateUserDto userDto)
    {
        var userId = await _userService.AddUserAsync(userDto);
        var createdUser = new UserDto
        {
            Id = userId,
            Username = userDto.Username,
            Email = userDto.Email
        };
        return CreatedAtAction(nameof(GetById), new { id = createdUser.Id }, createdUser);
    }

    [HttpGet("by-ids")]
    public async Task<IActionResult> GetByIds([FromQuery] string ids)
    {
        if (string.IsNullOrEmpty(ids)) return BadRequest("IDs are required");
        var idList = ids.Split(',').Select(int.Parse).ToList();
        var users = await _userService.GetUsersByIdsAsync(idList);
        return Ok(users);
    }
}
