using DotNetTestWebApi.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DotNetTestWebApi.Data.Contract
{
    public interface IProjectRepository
    {
        public List<Project> GetAllProjects();

        public Project GetProjectById(int projectId);

        public bool AddProject(Project project);

        public bool UpdateProject(Project project);

        public bool DeleteProject(int projectId);
    }
}
