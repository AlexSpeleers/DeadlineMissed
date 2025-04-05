using DeadlineMissed.Application.DTOs;
using DeadlineMissed.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace DeadlineMissed.Api.Controllers
{
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
    }
}
