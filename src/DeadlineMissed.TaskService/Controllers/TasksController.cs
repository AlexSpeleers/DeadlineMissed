using DeadlineMissed.TaskService.Application.DTOs;
using DeadlineMissed.TaskService.Application.Services;
using DeadlineMissed.TaskService.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DeadlineMissed.TaskService.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TasksController : ControllerBase
{
    private readonly ITodoTaskService _todoTaskService;

    public TasksController(ITodoTaskService todoTaskService)
    {
        _todoTaskService = todoTaskService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tasks = await _todoTaskService.GetAllTasksAsync();
        return Ok(tasks);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var task = await _todoTaskService.GetTaskByIdAsync(id);
        return Ok(task);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] TodoTaskDto todoTaskDto)
    {
        await _todoTaskService.AddTaskAsync(todoTaskDto);
        return CreatedAtAction(nameof(GetById), new { id = todoTaskDto.Id }, todoTaskDto);
    }

    [HttpPost("{id}/assign/{userId}")]
    public async Task<IActionResult> AssignTask(int id, int userId)
    {
        await _todoTaskService.AssignTaskToUserAsync(id, userId);
        return NoContent();
    }

    [HttpPost("{id}/unassign/{userId}")]
    public async Task<IActionResult> UnassignTask(int id, int userId)
    {
        await _todoTaskService.UnassignTaskFromUserAsync(id, userId);
        return NoContent();
    }

    [HttpPut("{id}/status")]
    public async Task<IActionResult> UpdateStatus(int id, [FromBody] TodoTaskStatus status)
    {
        await _todoTaskService.UpdateTaskStatusAsync(id, status);
        return NoContent();
    }
}
