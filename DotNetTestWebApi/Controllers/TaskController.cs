using DotNetTestWebApi.Dtos;
using DotNetTestWebApi.Services.Contract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTestWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("GetAllTasks")]
        public IActionResult GetAllTasks()
        {
            var response = _taskService.GetAllTasks();
            if (!response.Success)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpGet("GetTaskByTaskId/{taskId}")]
        public IActionResult GetTaskById(int taskId)
        {
            var response = _taskService.GetTaskById(taskId);

            if (!response.Success)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpGet("GetTaskByProjectId/{projectId}")]
        public IActionResult GetTaskByProjectId(int projectId)
        {
            var response = _taskService.GetTaskByProjectId(projectId);

            if (!response.Success)
            {
                return NotFound(response);
            }

            return Ok(response);
        }

        [HttpPost("AddTask")]
        public IActionResult AddTask(AddTaskDto taskDto)
        {
            var response = _taskService.AddTask(taskDto);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPut("UpdateTask")]
        public IActionResult UpdateTask(UpdateTaskDto taskDto)
        {
            var response = _taskService.UpdateTask(taskDto);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete("DeleteTask/{taskId}")]
        public IActionResult DeleteTask(int taskId)
        {
            var response = _taskService.DeleteTask(taskId);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
