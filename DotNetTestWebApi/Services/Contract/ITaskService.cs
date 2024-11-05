using DotNetTestWebApi.Dtos;
using DotNetTestWebApi.Models;

namespace DotNetTestWebApi.Services.Contract
{
    public interface ITaskService
    {
        public ServiceResponse<List<TaskDto>> GetAllTasks();

        public ServiceResponse<TaskDto> GetTaskById(int taskId);

        public ServiceResponse<List<TaskDto>> GetTaskByProjectId(int projectId);

        public ServiceResponse<string> AddTask(AddTaskDto taskDto);

        public ServiceResponse<string> UpdateTask(UpdateTaskDto taskDto);

        public ServiceResponse<string> DeleteTask(int taskId);
    }
}
