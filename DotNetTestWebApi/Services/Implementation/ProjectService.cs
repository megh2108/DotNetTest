using DotNetTestWebApi.Data.Contract;
using DotNetTestWebApi.Dtos;
using DotNetTestWebApi.Models;
using DotNetTestWebApi.Services.Contract;

namespace DotNetTestWebApi.Services.Implementation
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public ServiceResponse<List<ProjectDto>> GetAllProjects()
        {
            var response = new ServiceResponse<List<ProjectDto>>();
            var projects = _projectRepository.GetAllProjects();

            if (projects.Any())
            {
                response.Data = projects.Select(p => new ProjectDto
                {
                    ProjectId = p.ProjectId,
                    ProjectName = p.ProjectName,
                    Description = p.Description,
                    Deadline = p.Deadline,
                    CreatedAt = p.CreatedAt,
                    CreatedBy = p.CreatedBy
                }).ToList();
                response.Success = true;
            }
            else
            {
                response.Success = false;
                response.Message = "No projects found!";
            }

            return response;
        }

        public ServiceResponse<ProjectDto> GetProjectById(int projectId)
        {
            var response = new ServiceResponse<ProjectDto>();
            var project = _projectRepository.GetProjectById(projectId);

            if (project != null)
            {
                response.Data = new ProjectDto
                {
                    ProjectId = project.ProjectId,
                    ProjectName = project.ProjectName,
                    Description = project.Description,
                    Deadline = project.Deadline,
                    CreatedAt = project.CreatedAt,
                    CreatedBy = project.CreatedBy
                };
                response.Success = true;
            }
            else
            {
                response.Success = false;
                response.Message = "Project not found!";
            }

            return response;
        }

        public ServiceResponse<string> AddProject(AddProjectDto projectDto)
        {
            var response = new ServiceResponse<string>();

            var project = new Project
            {
                ProjectName = projectDto.ProjectName,
                Description = projectDto.Description,
                Deadline = projectDto.Deadline,
                CreatedBy = projectDto.CreatedBy
            };

            response.Success = _projectRepository.AddProject(project);
            response.Message = response.Success ? "Project added successfully." : "Error adding project.";
            return response;
        }

        public ServiceResponse<string> UpdateProject(UpdateProjectDto projectDto)
        {
            var response = new ServiceResponse<string>();

            var project = new Project
            {
                ProjectId = projectDto.ProjectId,
                ProjectName = projectDto.ProjectName,
                Description = projectDto.Description,
                Deadline = projectDto.Deadline
            };

            response.Success = _projectRepository.UpdateProject(project);
            response.Message = response.Success ? "Project updated successfully." : "Error updating project.";
            return response;
        }

        public ServiceResponse<string> DeleteProject(int projectId)
        {
            var response = new ServiceResponse<string>();
            response.Success = _projectRepository.DeleteProject(projectId);
            response.Message = response.Success ? "Project deleted successfully." : "Error deleting project.";
            return response;
        }
    }
}
