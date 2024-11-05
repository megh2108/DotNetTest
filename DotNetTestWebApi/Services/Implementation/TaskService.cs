using DotNetTestWebApi.Data.Contract;
using DotNetTestWebApi.Dtos;
using DotNetTestWebApi.Models;
using DotNetTestWebApi.Services.Contract;

namespace DotNetTestWebApi.Services.Implementation
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public ServiceResponse<List<TaskDto>> GetAllTasks()
        {
            var response = new ServiceResponse<List<TaskDto>>();
            var tasks = _taskRepository.GetAllTasks();

            if (tasks.Any())
            {
                List<TaskDto> taskDtos = tasks.Select(task => new TaskDto
                {
                    TaskId = task.TaskId,
                    ProjectId = task.ProjectId,
                    Title = task.Title,
                    Description = task.Description,
                    Priority = task.Priority,
                    Status = task.Status,
                    DueDate = task.DueDate,
                    AssignedTo = task.AssignedTo,
                    CreatedAt = task.CreatedAt,
                    CreatedBy = task.CreatedBy,
                    Project = new Project() 
                    {
                        ProjectId = task.Project.ProjectId,
                        ProjectName = task.Project.ProjectName,
                    },
                    AssignedUser = new User()
                    {
                        UserId = task.AssignedUser.UserId,
                        Username = task.AssignedUser.Username,
                    },
                    CreatedByUser = new User()
                    {
                        UserId = task.CreatedByUser.UserId,
                        Username = task.CreatedByUser.Username,
                    }
                }).ToList();

                response.Success = true;
                response.Data = taskDtos;
            }
            else
            {
                response.Success = false;
                response.Message = "No tasks found!";
            }

            return response;
        }

        public ServiceResponse<TaskDto> GetTaskById(int taskId)
        {
            var response = new ServiceResponse<TaskDto>();
            var task = _taskRepository.GetTaskById(taskId);

            if (task != null)
            {
                var taskDto = new TaskDto
                {
                    TaskId = task.TaskId,
                    ProjectId = task.ProjectId,
                    Title = task.Title,
                    Description = task.Description,
                    Priority = task.Priority,
                    Status = task.Status,
                    DueDate = task.DueDate,
                    AssignedTo = task.AssignedTo,
                    CreatedAt = task.CreatedAt,
                    CreatedBy = task.CreatedBy,
                    Project = new Project()
                    {
                        ProjectId = task.Project.ProjectId,
                        ProjectName = task.Project.ProjectName,
                    },
                    AssignedUser = new User()
                    {
                        Username = task.AssignedUser.Username,
                    },
                    CreatedByUser = new User()
                    {
                        Username = task.CreatedByUser.Username,
                    }
                };

                response.Data = taskDto;
                response.Success = true;
            }
            else
            {
                response.Success = false;
                response.Message = "Task not found!";
            }

            return response;
        }

        public ServiceResponse<List<TaskDto>> GetTaskByProjectId(int projectId)
        {
            var response = new ServiceResponse<List<TaskDto>>();
            var tasks = _taskRepository.GetTaskByProjectId(projectId);

            if (tasks.Any())
            {
                List<TaskDto> taskDtos = tasks.Select(task => new TaskDto
                {
                    TaskId = task.TaskId,
                    ProjectId = task.ProjectId,
                    Title = task.Title,
                    Description = task.Description,
                    Priority = task.Priority,
                    Status = task.Status,
                    DueDate = task.DueDate,
                    AssignedTo = task.AssignedTo,
                    CreatedAt = task.CreatedAt,
                    CreatedBy = task.CreatedBy
                }).ToList();

                response.Success = true;
                response.Data = taskDtos;
            }
            else
            {
                response.Success = false;
                response.Message = "No tasks found!";
            }

            return response;
        }


        public ServiceResponse<string> AddTask(AddTaskDto taskDto)
        {
            var response = new ServiceResponse<string>();

            var task = new Tasks
            {
                ProjectId = taskDto.ProjectId,
                Title = taskDto.Title,
                Description = taskDto.Description,
                Priority = taskDto.Priority,
                Status = taskDto.Status,
                DueDate = taskDto.DueDate,
                AssignedTo = taskDto.AssignedTo,
                CreatedAt = DateTime.Now,
                CreatedBy = taskDto.CreatedBy
            };

            var result = _taskRepository.AddTask(task);
            if (result)
            {
                response.Success = true;
                response.Message = "Task added successfully.";
            }
            else
            {
                response.Success = false;
                response.Message = "Something went wrong. Please try again.";
            }
            return response;
        }

        public ServiceResponse<string> UpdateTask(UpdateTaskDto taskDto)
        {
            var response = new ServiceResponse<string>();

            var task = new Tasks
            {
                TaskId = taskDto.TaskId,
                ProjectId = taskDto.ProjectId,
                Title = taskDto.Title,
                Description = taskDto.Description,
                Priority = taskDto.Priority,
                Status = taskDto.Status,
                DueDate = taskDto.DueDate,
                AssignedTo = taskDto.AssignedTo,
                CreatedBy = taskDto.CreatedBy
            };

            var result = _taskRepository.UpdateTask(task);
            if (result)
            {
                response.Success = true;
                response.Message = "Task updated successfully.";
            }
            else
            {
                response.Success = false;
                response.Message = "Something went wrong. Please try again.";
            }
            return response;
        }

        public ServiceResponse<string> DeleteTask(int taskId)
        {
            var response = new ServiceResponse<string>();
            var result = _taskRepository.DeleteTask(taskId);

            if (result)
            {
                response.Success = true;
                response.Message = "Task deleted successfully.";
            }
            else
            {
                response.Success = false;
                response.Message = "Something went wrong. Please try again.";
            }

            return response;
        }
    }
}
