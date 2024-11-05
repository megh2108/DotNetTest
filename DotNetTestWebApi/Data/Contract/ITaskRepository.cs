using DotNetTestWebApi.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace DotNetTestWebApi.Data.Contract
{
    public interface ITaskRepository
    {
        public List<Tasks> GetAllTasks();

        public Tasks GetTaskById(int taskId);

        public List<Tasks> GetTaskByProjectId(int projectId);

        public bool AddTask(Tasks task);

        public bool UpdateTask(Tasks task);

        public bool DeleteTask(int taskId);
    }
}
