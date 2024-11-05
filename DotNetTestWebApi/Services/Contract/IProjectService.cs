using DotNetTestWebApi.Dtos;
using DotNetTestWebApi.Models;

namespace DotNetTestWebApi.Services.Contract
{
    public interface IProjectService
    {
        public ServiceResponse<List<ProjectDto>> GetAllProjects();

        public ServiceResponse<ProjectDto> GetProjectById(int projectId);

        public ServiceResponse<string> AddProject(AddProjectDto projectDto);

        public ServiceResponse<string> UpdateProject(UpdateProjectDto projectDto);

        public ServiceResponse<string> DeleteProject(int projectId);
    }
}
