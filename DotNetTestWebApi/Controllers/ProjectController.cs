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
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("GetAllProjects")]
        public IActionResult GetAllProjects()
        {
            var response = _projectService.GetAllProjects();
            return response.Success ? Ok(response) : NotFound(response);
        }

        [HttpGet("GetProjectById/{projectId}")]
        public IActionResult GetProjectById(int projectId)
        {
            var response = _projectService.GetProjectById(projectId);
            return response.Success ? Ok(response) : NotFound(response);
        }

        [HttpPost("AddProject")]
        public IActionResult AddProject(AddProjectDto projectDto)
        {
            var response = _projectService.AddProject(projectDto);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpPut("UpdateProject")]
        public IActionResult UpdateProject(UpdateProjectDto projectDto)
        {
            var response = _projectService.UpdateProject(projectDto);
            return response.Success ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("DeleteProject/{projectId}")]
        public IActionResult DeleteProject(int projectId)
        {
            var response = _projectService.DeleteProject(projectId);
            return response.Success ? Ok(response) : BadRequest(response);
        }
    }
}
